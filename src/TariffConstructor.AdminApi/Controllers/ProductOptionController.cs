using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TariffConstructor.AdminApi.Dto;
using TariffConstructor.AdminApi.Mappers.ProductOptionAggregate;
using TariffConstructor.Domain.ProductOptionAggregate;

namespace TariffConstructor.AdminApi.Controllers
{
    [Route("productOption")]
    [ApiController]
    public class ProductOptionController : ControllerBase
    {
        private readonly IProductOptionRepository productOptionRepository;

        public ProductOptionController(IProductOptionRepository productOptionRepository)
        {
            this.productOptionRepository = productOptionRepository;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetProductOption()
        {
            var productOptions = await productOptionRepository.GetProductOptions();
            return Ok(productOptions.Map());
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetProductOption(int id)
        {
            ProductOption productOption = await productOptionRepository.GetProductOption(id);
            return Ok(productOption.Map());
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddProductOption([FromBody]ProductOptionDto productOptionDto)
        {
            var productOption = new ProductOption(productOptionDto.ProductId, 
                productOptionDto.Name, productOptionDto.IsMultiple);
            productOption.SetAccountingName(productOptionDto.AccountingName);
            productOption.SetNomenclatureId(productOptionDto.NomenclatureId);
            //productOption.SetKindId(productOptionDto.KindId);

            await productOptionRepository.Add(productOption);
            return Ok();
        }

        [HttpDelete("")]
        public async Task<IActionResult> Delete(int id)
        {
            await productOptionRepository.Delete(id);
            return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> Change([FromBody] ProductOptionDto productOptionDto)
        {
            ProductOption productOption = await productOptionRepository.GetProductOption(productOptionDto.Id);

            productOption.SetAccountingName(productOptionDto.AccountingName);
            productOption.SetIsMultiple(productOptionDto.IsMultiple);
            productOption.SetName(productOptionDto.Name);
            productOption.SetNomenclatureId(productOptionDto.NomenclatureId);
            productOption.SetProductId(productOptionDto.ProductId);

            productOption = await productOptionRepository.Update(productOption);

            return Ok(productOption.Map());
        }
    }
}
