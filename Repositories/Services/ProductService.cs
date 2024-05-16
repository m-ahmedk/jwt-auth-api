using jwt_authentication.Models;
using jwt_authentication.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace jwt_authentication.Repositories.Services
{
    public class ProductService : IProduct
    {

        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product?> AddProduct(Product productObj)
        {
            bool isSuccess = false;

            if (productObj.ProductId > 0)
            {
                await _context.Products.AddAsync(productObj);
                isSuccess = await _context.SaveChangesAsync() > 0;
            }

            return isSuccess ? productObj : null;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            bool isSuccess = false;
            var _productObj = await GetById(id);

            if(_productObj != null)
            {
                _context.Products.Remove(_productObj);
                isSuccess = await _context.SaveChangesAsync() > 0;
            }

            return isSuccess;            
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetById(int id)
        {
            Product? _productObj = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == id);
            return _productObj;
        }

        public async Task<Product?> UpdateProduct(int id, Product productObj)
        {
            bool isSuccess = false;

            var _productObj = await GetById(id);

            if (_productObj != null) {
                _productObj.Description = productObj.Description;
                _productObj.Price = productObj.Price;
                _productObj.isInStock = productObj.isInStock;

                _context.Products.Update(_productObj);
                isSuccess = await _context.SaveChangesAsync() > 0;
            }

            return isSuccess ? _productObj : null;
        }
    }
}
