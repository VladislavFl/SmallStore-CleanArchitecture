using Microsoft.AspNetCore.Mvc;
using SmallStore.Core.Abstractions;
using SmallStore.Core.Models;
using SmallStoreCA.API.Contracts;

namespace SmallStoreCA.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductsResponse>>> GetProducts()
        {
            var products = await _productsService.GetAllProducts();

            var response = products.Select(x => new ProductsResponse(x.Id, x.Name, x.Description, x.Price));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateProduct([FromBody] ProductsRequest productsRequest)
        {
            var (product, error) = Product.Create(
                Guid.NewGuid(),
                productsRequest.Name,
                productsRequest.Description,
                productsRequest.Price);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var productId = await _productsService.CreateProduct(product);

            return Ok(productId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateProduct(Guid id, [FromBody] ProductsRequest productsRequest)
        {
            var productId = await _productsService.UpdateProduct(id, productsRequest.Name, productsRequest.Description, productsRequest.Price);

            return Ok(productId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteProduct(Guid id)
        {
            return await _productsService.DeleteProduct(id);
        }
    }
}
