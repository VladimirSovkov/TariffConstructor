using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TariffConstructor.AdminApi.Dto.ProductOptionTariff;
using TariffConstructor.AdminApi.Mappers.ProductOptionTariffMap;
using TariffConstructor.Domain.ProductOptionTariffAggregate;
using TariffConstructor.Domain.SearchPattern;
using TariffConstructor.Domain.ValueObjects;
using TariffConstructor.Toolkit.Search;

namespace TariffConstructor.AdminApi.Controllers
{
    [Route("productOptionTariff")]
    [ApiController]
    public class ProductOptionTariffController : ControllerBase
    {
        private readonly IProductOptionTariffRepository productOptionTariffRepository;

        public ProductOptionTariffController(IProductOptionTariffRepository productOptionTariffRepository)
        {
            this.productOptionTariffRepository = productOptionTariffRepository;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] ProductOptionTariffDto productOptionTariffDto)
        {
            ProductOptionTariff productOptionTariff = new ProductOptionTariff(
                productOptionTariffDto.ProductOptionId,
                productOptionTariffDto.Name);
            foreach (var priceItem in productOptionTariffDto.Prices)
            {
                Price price = new Price(priceItem.Price.Value, priceItem.Price.Currency);
                ProlongationPeriod prolongationPeriod = new ProlongationPeriod(priceItem.Period.Value, (PeriodUnit)priceItem.Period.periodUnit);
                productOptionTariff.AddPriceItem(price, prolongationPeriod);
            }
            productOptionTariff = await productOptionTariffRepository.Add(productOptionTariff);
            return Ok(productOptionTariff.Map());
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetProductOptionTariff(int id)
        {
            ProductOptionTariff productOptionTariff = await productOptionTariffRepository.GetProductOptionTariff(id);
            if (productOptionTariff == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"ProductOptionTariff id == {id}. Not found!");
            }
            return Ok(productOptionTariff.Map());
        }

        [HttpDelete("")]
        public async Task<IActionResult> Delete(int id)
        {
            await productOptionTariffRepository.Delete(id);
            return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] ProductOptionTariffDto productOptionTariffDto)
        {
            ProductOptionTariff productOptionTariff = await productOptionTariffRepository.GetProductOptionTariff(productOptionTariffDto.Id);
            if (productOptionTariff == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"ProductOptionTariff id == {productOptionTariffDto.Id}. Not found!");
            }
            
            

            await productOptionTariffRepository.Update(productOptionTariff);
            return Ok();
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(int pageNumber, int onPage, string searchString)
        {
            var abc = new ProductOptionTariffSearchPattern();
            abc.PageNumber = pageNumber;
            abc.OnPage = onPage;
            abc.SearchString = searchString;
            SearchResult<ProductOptionTariff> searchResult = await productOptionTariffRepository.Search(abc);

            return Ok(new SearchResult<ProductOptionTariffDto>
            {
                Items = searchResult.Items.Map(),
                TotalCount = searchResult.TotalCount,
                FilteredCount = searchResult.FilteredCount
            });
        }
    }
}
