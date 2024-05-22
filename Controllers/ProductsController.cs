using jwt_authentication.Helpers.Filters;
using jwt_authentication.Models;
using jwt_authentication.Models.DTOs;
using jwt_authentication.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace jwt_authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] bool? inStock = null)
        {
            var products = await _productService.GetAll(inStock);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var product = await _productService.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            var productObj = await _productService.AddProduct(product);

            if (productObj == null)
            {
                return BadRequest(productObj);
            }

            return Ok(new
            {
                message = "A new product has been created!",
                id = productObj!.ProductId
            });
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> Patch([FromRoute] int id, [FromBody] ProductDto productdto)
        {
            var product = await _productService.UpdateProduct(id, productdto);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "The product has been updated successfully!",
                product
            });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if(!await _productService.DeleteProduct(id))
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "The product has been deleted successfully!",
                productid = id
            });
        }
    }
}
