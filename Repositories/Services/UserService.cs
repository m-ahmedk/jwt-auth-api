using jwt_authentication.Models;
using jwt_authentication.Models.DTOs;
using jwt_authentication.Models.RequestModel;
using jwt_authentication.Models.ResponseModel;
using jwt_authentication.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace jwt_authentication.Repositories.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IJwtService _jwtService;

        public UserService(ApplicationDbContext context, IJwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        public async Task<User?> AddUser(User user)
        {
            bool isSuccess = false;

            await _context.Users.AddAsync(user);
            isSuccess = await _context.SaveChangesAsync() > 0;

            return isSuccess ? user : null;
        }

        public async Task<User?> UpdateUser(int id, UserDto userdto)
        {
            bool isSuccess = false;

            var user = await GetById(id);

            if (user != null)
            {
                _ = !string.IsNullOrEmpty(userdto.FirstName) ?
                    user.FirstName = userdto.FirstName : null;

                _ = !string.IsNullOrEmpty(userdto.LastName) ?
                    user.LastName = userdto.LastName : null;

                _context.Users.Update(user);
                isSuccess = await _context.SaveChangesAsync() > 0;
            }

            return isSuccess ? user : null;
        }

        public async Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Username == model.Username && x.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = await _jwtService.GenerateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetById(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == id);
            return user;
        }

    }
}
