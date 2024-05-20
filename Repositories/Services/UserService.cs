using jwt_authentication.Models;
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

        public async Task<User?> AddAndUpdateUser(User userObj)
        {
            bool isSuccess = false;
            if (userObj.UserId > 0)
            {
                var obj = await _context.Users.FirstOrDefaultAsync(c => c.UserId == userObj.UserId);
                if (obj != null)
                {
                    obj.FirstName = userObj.FirstName;
                    obj.LastName = userObj.LastName;
                    _context.Users.Update(obj);
                    isSuccess = await _context.SaveChangesAsync() > 0;
                }
            }
            else
            {
                await _context.Users.AddAsync(userObj);
                isSuccess = await _context.SaveChangesAsync() > 0;
            }

            return isSuccess ? userObj : null;
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
            return await _context.Users.FirstOrDefaultAsync(x => x.UserId == id);
        }
    }
}
