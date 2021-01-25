using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TariffConstructor.AdminApi.Dto;
using TariffConstructor.Domain.TariffModel;
using TariffConstructor.AdminApi.Mappers.TariffMap;
using TariffConstructor.Domain.ContractModel;
using TariffConstructor.Toolkit.Search;
using Microsoft.AspNetCore.Http;
using TariffConstructor.Domain.ValueObjects;
using System;
using TariffConstructor.Domain.ProductModel;
using TariffConstructor.AdminApi.Dto.TariffAggragate;
using TariffConstructor.Domain.ProductOptionModel;

namespace TariffConstructor.AdminApi.Controllers
{
    [Route("tariff")]
    public class TariffController : ControllerBase
    {

        private readonly ITariffRepository tariffRepository;
        private readonly IProductRepository productRepository;
        private readonly IProductOptionRepository productOptionRepository;

        public TariffController(
            ITariffRepository tariffRepository
            , IProductRepository productRepository
            , IProductOptionRepository productOptionRepository)
        {
            this.tariffRepository = tariffRepository;
            this.productRepository = productRepository;
            this.productOptionRepository = productOptionRepository;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetTariff(int id)
        {
            Tariff tariff = await tariffRepository.GetTariff(id);
            return Ok(tariff);
        }


        [HttpGet("search")]
        [ProducesResponseType(typeof(SearchResult<SimplifiedTariffDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int pageNumber, int onPage, string searchString)
        {
            var abc = new TarifftSearchPattern();
            abc.PageNumber = pageNumber;
            abc.OnPage = onPage;
            abc.SearchString = searchString;
            SearchResult<Tariff> searchResult = await tariffRepository.GetFoundTariff(abc);

            return Ok(new SearchResult<SimplifiedTariffDto>
            {
                Items = searchResult.Items.ToSimplifiedTariffDtos(),
                TotalCount = searchResult.TotalCount,
                FilteredCount = searchResult.FilteredCount
            });
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] TariffDto tariffDto)
        {
            Tariff tariff = new Tariff(tariffDto.Name, (PaymentType)tariffDto.PaymentType);
            TariffTestPeriod testPeriod = new TariffTestPeriod(tariffDto.TestPeriod.Value, (TariffTestPeriodUnit)tariffDto.TestPeriod.Unit);
            tariff.SetArchive(tariffDto.IsArchived);
            tariff.AddTestPeriod(testPeriod);
            tariff.SetAccountingTariffId(tariffDto.AccountingName);
            tariff.SetSettingsPresetId(tariffDto.SettingsPresetId);
            tariff.SetTermsOfUseId(tariffDto.TermsOfUseId);
            tariff.SetIsAcceptanceRequired(tariffDto.IsAcceptanceRequired);
            tariff.SetIsGradualFinishAvailable(tariffDto.IsGradualFinishAvailable);

            //add price 
            //foreach(var tariffPrice in tariffLoad.Prices)
            //{
            //    Price price = new Price(tariffPrice.Price.Value, tariffPrice.Price.Currency);
            //    ProlongationPeriod period = new ProlongationPeriod(tariffPrice.Period.Value, (PeriodUnit)Convert.ToInt32(tariffPrice.Period.periodUnit));
            //    tariff.AddPriceItem(price, period);
            //}
            
            //add included product
            foreach (var includedProduct in tariffDto.IncludedProducts)
            {
                Product product = await productRepository.GetProduct(includedProduct.ProductId);
                tariff.AddProduct(product, includedProduct.RelativeWeight);
            }

            //add product option
            //foreach (var includedProductOption in tariffLoad.IncludedProductOptions)
            //{
            //    ProductOption productOption = await productOptionRepository.GetProductOption(includedProductOption.ProductOptionId);
            //    tariff.AddProductOption(productOption, includedProductOption.Quantity);
            //}
            
            await tariffRepository.Add(tariff);

            return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody]TariffLoadParameters tariffLoad)
        {
            //PaymentType paymentType = (PaymentType)Convert.ToInt32(tariffLoad.PaymentType);
            //Tariff tariff = new Tariff(tariffLoad.Name, paymentType);
            //tariff.SetAccountingTariffId(tariffLoad.AccountingTariffId);
            //tariff.SetAwaitingPaymentStrategy(tariffLoad.AwaitingPaymentStrategy);
            //tariff.SetSettingsPresetId(tariffLoad.SettingsPresetId);
            //tariff.SetTermsOfUseId(tariffLoad.TermsOfUseId);
            //if (tariffLoad.IsArchived)
            //    tariff.Archive();
            //tariff.AddTestPeriod(new TariffTestPeriod(tariffLoad.Value, (TariffTestPeriodUnit)Convert.ToInt32(tariffLoad.Unit)));
            //foreach (var includedProduct in tariff.IncludedProducts)
            //{
            //    Product product = await productRepository.GetProduct(includedProduct.ProductId);
            //    tariff.AddProduct(product, includedProduct.RelativeWeight);
            //}
            //await tariffRepository.Add(tariff);

            return Ok();
        }

        [HttpDelete("")]
        public async Task<IActionResult> Delete(int id)
        {
            await tariffRepository.Delete(id);
            return Ok();
        }
    }
}
