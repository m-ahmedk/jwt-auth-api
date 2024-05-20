using jwt_authentication.Models;

namespace jwt_authentication.Repositories.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAll(bool? inStock);
        Task<Product?> GetById(int id);
        Task<Product?> AddProduct(Product productObj);
        Task<Product?> UpdateProduct(int id, Product productObj);
        Task<bool> DeleteProduct(int id);
    }
}
