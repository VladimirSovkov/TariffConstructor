using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TariffConstructor.Domain.ProductOptionModel;
using TariffConstructor.Toolkit.Abstractions;
using TariffConstructor.Toolkit.Search;

namespace TariffConstructor.AdminApi.Modules.ProductOptionModule
{
    [Route("productOptions")]
    [ApiController]
    public class ProductOptionController : ControllerBase
    {
        private readonly IProductOptionRepository productOptionRepository;
        private readonly IUnitOfWork unitOfWork;

        public ProductOptionController(IProductOptionRepository productOptionRepository,
            IUnitOfWork unitOfWork)
        {
            this.productOptionRepository = productOptionRepository;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetProductOption()
        {
            var productOptions = await productOptionRepository.GetProductOptions();
            return Ok(productOptions.Map());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductOption(int id)
        {
            ProductOption productOption = await productOptionRepository.GetProductOption(id);
            return Ok(productOption.Map());
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(int pageNumber, int onPage, string searchString)
        {
            var abc = new ProductOptionSearchPattern
            {
                PageNumber = pageNumber,
                OnPage = onPage,
                SearchString = searchString
            };
            SearchResult<ProductOption> searchResult = await productOptionRepository.Search(abc);

            return Ok(new SearchResult<ProductOptionDto>
            {
                Items = searchResult.Items.Map(),
                TotalCount = searchResult.TotalCount,
                FilteredCount = searchResult.FilteredCount
            });
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddProductOption([FromBody]ProductOptionDto productOptionDto)
        {
            if (await productOptionRepository.GetProductOption(productOptionDto.PublicId) != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"ProductOption with this PublicId == {productOptionDto.PublicId} already exists");
            }
            var productOption = new ProductOption(productOptionDto.ProductId, 
                productOptionDto.Name, productOptionDto.IsMultiple, productOptionDto.PublicId);
            productOption.SetAccountingName(productOptionDto.AccountingName);
            productOption.SetNomenclatureId(productOptionDto.NomenclatureId);
            //productOption.SetKindId(productOptionDto.KindId);

            await productOptionRepository.Add(productOption);
            await unitOfWork.SaveEntitiesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await productOptionRepository.Delete(id);
            await unitOfWork.SaveEntitiesAsync();
            return Ok();
        }

        [HttpPost("")]
        public async Task<IActionResult> Change([FromBody] ProductOptionDto productOptionDto)
        {
            ProductOption productOption = await productOptionRepository.GetProductOption(productOptionDto.Id);

            if (productOption.PublicId != productOptionDto.PublicId)
            {
                if (await productOptionRepository.GetProductOption(productOptionDto.PublicId) != null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"ProductOption with this PublicId == {productOptionDto.PublicId} already exists");
                }
                productOption.SetPublicId(productOptionDto.PublicId);
            }

            productOption.SetAccountingName(productOptionDto.AccountingName);
            productOption.SetIsMultiple(productOptionDto.IsMultiple);
            productOption.SetName(productOptionDto.Name);
            productOption.SetNomenclatureId(productOptionDto.NomenclatureId);
            productOption.SetProductId(productOptionDto.ProductId);

            await productOptionRepository.Update(productOption);
            await unitOfWork.SaveEntitiesAsync();

            return Ok();
        }
    }
}
