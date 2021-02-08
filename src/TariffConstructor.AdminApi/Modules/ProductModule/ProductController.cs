using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TariffConstructor.Domain.ProductModel;
using Microsoft.AspNetCore.Http;
using TariffConstructor.Toolkit.Search;
using TariffConstructor.Toolkit.Abstractions;

namespace TariffConstructor.AdminApi.Modules.ProductModule
{
    [Route("products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        private readonly IUnitOfWork unitOfWork;

        public ProductController (IProductRepository productRepository,
            IUnitOfWork unitOfWork)
        {
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await productRepository.GetProducts();
            return Ok(products.Map());
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] ProductDto productDto)
        {
            if (await productRepository.GetProduct(productDto.PublicId) != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Product with this PublicId == {productDto.PublicId} already exists");
            }

            Product product = new Product(productDto.Name, productDto.PublicId, productDto.ShortName);
            product.SetNomenclatureId(productDto.NomenclatureId);
            await productRepository.Add(product);
            await unitOfWork.SaveEntitiesAsync();
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id )
        {
            Product product = await productRepository.GetProduct(id);
            return Ok(product.Map());
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(int pageNumber, int onPage, string searchString)
        {
            var abc = new ProductSearchPattern
            {
                PageNumber = pageNumber,
                OnPage = onPage,
                SearchString = searchString
            };
            SearchResult<Product> searchResult = await productRepository.Search(abc);

            return Ok(new SearchResult<ProductDto>
            {
                Items = searchResult.Items.Map(),
                TotalCount = searchResult.TotalCount,
                FilteredCount = searchResult.FilteredCount
            });
        }

        [HttpPost("")]
        public async Task<IActionResult> Update(ProductDto productDto)
        {
            Product product = await productRepository.GetProduct(productDto.Id);
            if (product == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Product id == {productDto.Id}. Not found!");
            }

            if (product.PublicId != productDto.PublicId)
            {
                if (await productRepository.GetProduct(productDto.PublicId) != null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Product with this PublicId == {productDto.PublicId} already exists");
                }
                product.SetPublicId(productDto.PublicId);
            }

            product.SetPublicId(productDto.PublicId);
            product.SetName(productDto.Name);
            product.SetShortName(productDto.ShortName);
            product.SetNomenclatureId(productDto.NomenclatureId);
            await productRepository.Update(product);
            await unitOfWork.SaveEntitiesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await productRepository.Delete(id);
            await unitOfWork.SaveEntitiesAsync();
            return Ok();
        }
    }
}
