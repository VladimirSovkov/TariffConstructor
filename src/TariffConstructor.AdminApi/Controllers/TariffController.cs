using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TariffConstructor.AdminApi.Dto;
using TariffConstructor.Domain.TariffAggregate;
using TariffConstructor.AdminApi.Mappers.TariffAggregate;
using TariffConstructor.Domain.ContractModel;
using TariffConstructor.Toolkit.Search;
using Microsoft.AspNetCore.Http;
using TariffConstructor.Domain.ValueObjects;
using System;
using TariffConstructor.Domain.ProductAggregate;
using TariffConstructor.AdminApi.Dto.TariffAggragate;
using TariffConstructor.Domain.ProductOptionAggregate;

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

        [HttpGet(Name = "getTariff")]
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
            SearchResult<Tariff> searchResult = await tariffRepository.GetFoundRates(abc);

            return Ok(new SearchResult<SimplifiedTariffDto>
            {
                Items = searchResult.Items.ToSimplifiedTariffDtos(),
                TotalCount = searchResult.TotalCount,
                FilteredCount = searchResult.FilteredCount
            });
        }

        // POST tariff/add
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] TariffDto tariffLoad)
        {
            PaymentType paymentType = (PaymentType)Convert.ToInt32(tariffLoad.PaymentType);
            Tariff tariff = new Tariff(tariffLoad.Name, paymentType);
            tariff.SetAccountingTariffId(tariffLoad.AccountingTariffId);
            tariff.SetAwaitingPaymentStrategy(tariffLoad.AwaitingPaymentStrategy);
            tariff.SetSettingsPresetId(tariffLoad.SettingsPresetId);
            tariff.SetTermsOfUseId(tariffLoad.TermsOfUseId);
            if (tariffLoad.IsArchived)
                tariff.Archive();
            tariff.AddTestPeriod(new TariffTestPeriod(tariffLoad.ValueTestPeriod, (TariffTestPeriodUnit)Convert.ToInt32(tariffLoad.UnitTestPeriod)));
            
            //add price 
            //foreach(var tariffPrice in tariffLoad.Prices)
            //{
            //    Price price = new Price(tariffPrice.Price.Value, tariffPrice.Price.Currency);
            //    ProlongationPeriod period = new ProlongationPeriod(tariffPrice.Period.Value, (PeriodUnit)Convert.ToInt32(tariffPrice.Period.periodUnit));
            //    tariff.AddPriceItem(price, period);
            //}
            
            //add included product
            foreach (var includedProduct in tariffLoad.IncludedProducts)
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
            PaymentType paymentType = (PaymentType)Convert.ToInt32(tariffLoad.PaymentType);
            Tariff tariff = new Tariff(tariffLoad.Name, paymentType);
            tariff.SetAccountingTariffId(tariffLoad.AccountingTariffId);
            tariff.SetAwaitingPaymentStrategy(tariffLoad.AwaitingPaymentStrategy);
            tariff.SetSettingsPresetId(tariffLoad.SettingsPresetId);
            tariff.SetTermsOfUseId(tariffLoad.TermsOfUseId);
            if (tariffLoad.IsArchived)
                tariff.Archive();
            tariff.AddTestPeriod(new TariffTestPeriod(tariffLoad.Value, (TariffTestPeriodUnit)Convert.ToInt32(tariffLoad.Unit)));
            foreach (var includedProduct in tariff.IncludedProducts)
            {
                Product product = await productRepository.GetProduct(includedProduct.ProductId);
                tariff.AddProduct(product, includedProduct.RelativeWeight);
            }
            await tariffRepository.Add(tariff);

            return Ok();
        }

        [HttpPost("addProduct")]
        public void AddProduct()
        {

        }

        [HttpPost("addProductOption")]
        public void AddProductOption()
        {

        }

        [HttpDelete("")]
        public void Delete(int id)
        {
        }
    }
}
