using System.Text.Json.Serialization;

namespace jwt_authentication.Models
{
    public class Product 
    {
        public int ProductId { get; set; }
        public required string ProductName { get; set; }
        public required double Price { get; set; }
        public string Description { get; set; }
        public bool isInStock { get; set; }
    }
}
