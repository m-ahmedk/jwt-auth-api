using System.ComponentModel;

namespace jwt_authentication.Models.RequestModel
{
    public class AuthenticateRequest
    {
        public required string Username { get; set; }

        public required string Password { get; set; }
    }
}
