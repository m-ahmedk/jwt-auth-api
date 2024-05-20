using jwt_authentication.Models;
using jwt_authentication.Models.RequestModel;
using jwt_authentication.Models.ResponseModel;

namespace jwt_authentication.Repositories.Interfaces
{
    public interface IUserService
    {
        Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model);
        Task<IEnumerable<User>> GetAll();
        Task<User?> GetById(int id);
        Task<User?> AddAndUpdateUser(User userObj);
    }
}
