using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json.Serialization;

namespace jwt_authentication.Models.DTOs
{
    public class UserDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool? isActive { get; set; }
    }
}
