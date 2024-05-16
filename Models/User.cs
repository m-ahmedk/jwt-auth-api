using System.Text.Json.Serialization;

namespace jwt_authentication.Models
{
    public class User
    {
        public int UserId { get; set; }
        public required string FirstName { get; set; }
        public string LastName { get; set; }
        public required string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
        public bool isActive { get; set; }
    }
}
