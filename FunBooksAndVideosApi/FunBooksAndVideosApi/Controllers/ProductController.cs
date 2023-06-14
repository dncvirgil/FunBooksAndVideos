using FunBooksAndVideos.Api.Model;
using FunBooksAndVideos.Domain;
using FunBooksAndVideos.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FunBooksAndVideos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        // GET: api/Product?productType=Book
        /// <summary>
        /// Retrieves a list of products based on the specified product type.
        /// </summary>
        /// <param name="productType">The type of product to filter by.</param>
        /// <returns>A list of products matching the specified product type.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Product>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(string productType)
        {
            ProductTypeEnum productTypeEnum;
            if (!Enum.TryParse(productType, out productTypeEnum))
            {
                return BadRequest("Product type is invalid");
            }
            var products = await productService.GetProducts(productTypeEnum);
            
            if (!products.Any())
            {
                return NoContent();
            }
            
            return Ok(products);
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            //TODO: Add implementation
            return Ok();
        }

        // POST: api/Product
        [HttpPost()]
        public async Task<IActionResult> AddProduct(AddProductRequest request)
        {
            //TODO: Add implementation
            return Ok();
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            //TODO: Add implementation
            return Ok();
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, AddProductRequest request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }

            //TODO: Add implementation
            return Ok();
        }
    }
}
