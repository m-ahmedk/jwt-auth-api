using System.ComponentModel;

namespace jwt_authentication.Models.RequestModel
{
    public class AuthenticateRequest
    {
        [DefaultValue("Ahmed")]
        public required string Username { get; set; }

        [DefaultValue("qwerty12345")]
        public required string Password { get; set; }
    }
}
