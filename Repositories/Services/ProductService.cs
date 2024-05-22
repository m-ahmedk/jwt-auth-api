using jwt_authentication.Helpers.Filters;
using jwt_authentication.Models;
using jwt_authentication.Models.DTOs;
using jwt_authentication.Models.RequestModel;
using jwt_authentication.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;

namespace jwt_authentication.Repositories.Services
{
    public class ProductService : IProductService
    {

        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product?> AddProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            bool isSuccess = await _context.SaveChangesAsync() > 0;

            return isSuccess ? product : null;
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

        public async Task<IEnumerable<Product>> GetAll(bool? inStock)
        {
            return await _context.Products.Where(x => x.isInStock == inStock).ToListAsync();
        }

        public async Task<Product?> GetById(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == id);
            return product;
        }

        public async Task<Product?> UpdateProduct(int id, ProductDto productdto)
        {
            bool isSuccess = false;

            var product = await GetById(id);

            if (product != null) {

                _ = !string.IsNullOrEmpty(productdto.Description) ?
                    product.Description = productdto.Description : null;

                _ = productdto.Price.HasValue ?
                    product.Price = productdto.Price : null;
                
                _ = productdto.isInStock.HasValue ?
                    product.isInStock = productdto.isInStock : null;

                _context.Products.Update(product);
                isSuccess = await _context.SaveChangesAsync() > 0;
            }

            return isSuccess ? product : null;
        }
    }
}
