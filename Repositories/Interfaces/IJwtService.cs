using jwt_authentication.Models;

namespace jwt_authentication.Repositories.Interfaces
{
    public interface IJwtService
    {
        Task<string> GenerateJwtToken(User user);
    }
}
