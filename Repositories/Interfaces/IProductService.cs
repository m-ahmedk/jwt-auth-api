using jwt_authentication.Models;
using jwt_authentication.Models.DTOs;

namespace jwt_authentication.Repositories.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAll(bool? inStock);
        Task<Product?> GetById(int id);
        Task<Product?> AddProduct(Product product);
        Task<Product?> UpdateProduct(int id, ProductDto productdto);
        Task<bool> DeleteProduct(int id);
    }
}
