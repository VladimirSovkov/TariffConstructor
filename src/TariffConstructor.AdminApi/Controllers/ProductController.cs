using System.Threading.Tasks;
using TariffConstructor.AdminApi.Mappers.ProductAggregate;
using Microsoft.AspNetCore.Mvc;
using TariffConstructor.Domain.ProductModel;
using TariffConstructor.AdminApi.Dto;
using Microsoft.AspNetCore.Http;

namespace TariffConstructor.AdminApi.Controllers
{
    [Route("product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController (IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await productRepository.GetProducts();
            return Ok(products.Map());
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] ProductDto productDto)
        {
            Product product = new Product(productDto.Name, null, productDto.ShortName);
            product.SetNomenclatureId(productDto.NomenclatureId);
            product = await productRepository.Add(product);
            return Ok(product.Map());
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetProduct(int id )
        {
            Product product = await productRepository.GetProduct(id);
            return Ok(product.Map());
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(ProductDto productDto)
        {
            Product product = await productRepository.GetProduct(productDto.Id);
            if (product == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Product id == {productDto.Id}. Not found!");
            }
            product.SetName(productDto.Name);
            product.SetShortName(productDto.ShortName);
            product.SetNomenclatureId(productDto.NomenclatureId);
            await productRepository.Update(product);
            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await productRepository.Delete(id);
            return Ok();
        }
    }
}
