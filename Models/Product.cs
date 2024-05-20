using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace jwt_authentication.Models
{
    public class Product 
    {
        [SwaggerSchema(ReadOnly = true)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public required string ProductName { get; set; }
        public required double Price { get; set; }
        public string Description { get; set; }
        public bool isInStock { get; set; } = true;
    }
}
