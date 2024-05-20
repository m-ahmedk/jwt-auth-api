namespace jwt_authentication.Models.RequestModel
{
    public class ProductsModel
    {
        public required double Price { get; set; }
        public string Description { get; set; }
        public bool isInStock { get; set; }
    }
}
