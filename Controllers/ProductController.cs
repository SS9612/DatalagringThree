using Buisness.Services;
using Buisness.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.ConsoleApp.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductRegistrationForm form)
        {
            if (form == null || string.IsNullOrWhiteSpace(form.ProductName) || form.Price <= 0)
            {
                return BadRequest("Invalid product data.");
            }

            await _productService.CreateProductAsync(form);
            return CreatedAtAction(nameof(GetProductById), new { id = form.ProductName }, form);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetProductsAsync();
            if (products == null || !products.Any())
            {
                return NotFound("No products found.");
            }

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound("Product not found.");
            }

            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            if (updatedProduct == null || string.IsNullOrWhiteSpace(updatedProduct.ProductName) || updatedProduct.Price <= 0)
            {
                return BadRequest("Invalid product data.");
            }

            updatedProduct.Id = id;
            var success = await _productService.UpdateProductAsync(updatedProduct);
            if (!success)
            {
                return NotFound("Product not found.");
            }

            return Ok("Product updated successfully!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var success = await _productService.DeleteProductAsync(id);
            if (!success)
            {
                return NotFound("Product not found.");
            }

            return Ok("Product deleted successfully!");
        }
    }
}
