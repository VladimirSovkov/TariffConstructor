using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TariffConstructor.AdminApi.Dto;
using TariffConstructor.Domain.TariffModel;
using TariffConstructor.AdminApi.Mappers.TariffMap;
using TariffConstructor.Toolkit.Search;
using Microsoft.AspNetCore.Http;
using TariffConstructor.Domain.ValueObjects;
using System;
using TariffConstructor.Domain.ProductModel;
using TariffConstructor.AdminApi.Dto.TariffAggragate;
using TariffConstructor.Domain.ProductOptionModel;
using System.Linq;
using TariffConstructor.Domain.ContractKindModel;

namespace TariffConstructor.AdminApi.Controllers
{
    [Route("tariff")]
    public class TariffController : ControllerBase
    {

        private readonly ITariffRepository tariffRepository;
        private readonly IProductRepository productRepository;
        private readonly IProductOptionRepository productOptionRepository;
        private readonly IContractKindRepository contractKindRepository;

        public TariffController(
            ITariffRepository tariffRepository,
            IProductRepository productRepository,
            IProductOptionRepository productOptionRepository,
            IContractKindRepository contractKindRepository)
        {
            this.tariffRepository = tariffRepository;
            this.productRepository = productRepository;
            this.productOptionRepository = productOptionRepository;
            this.contractKindRepository = contractKindRepository;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetTariff(int id)
        {
            Tariff tariff = await tariffRepository.GetTariff(id);
            return Ok(tariff.Map());
        }


        [HttpGet("search")]
        [ProducesResponseType(typeof(SearchResult<SimplifiedTariffDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int pageNumber, int onPage, string searchString)
        {
            var abc = new TarifftSearchPattern
            {
                PageNumber = pageNumber,
                OnPage = onPage,
                SearchString = searchString
            };
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
            if (tariffDto.TestPeriod.Value != 0)
            {
                TariffTestPeriod testPeriod = new TariffTestPeriod(tariffDto.TestPeriod.Value, (TariffTestPeriodUnit)tariffDto.TestPeriod.Unit);
                tariff.AddTestPeriod(testPeriod);
            }
            tariff.SetArchive(tariffDto.IsArchived);
            tariff.SetAccountingTariffId(tariffDto.AccountingName);
            tariff.SetAwaitingPaymentStrategy(tariffDto.AwaitingPaymentStrategy);
            tariff.SetSettingsPresetId(tariffDto.SettingsPresetId);
            tariff.SetTermsOfUseId(tariffDto.TermsOfUseId);
            tariff.SetIsAcceptanceRequired(tariffDto.IsAcceptanceRequired);
            tariff.SetIsGradualFinishAvailable(tariffDto.IsGradualFinishAvailable);

            //add price 
            foreach (var tariffPrice in tariffDto.Prices)
            {
                Price price = new Price(tariffPrice.Price.Value, tariffPrice.Price.Currency);
                ProlongationPeriod period = new ProlongationPeriod(tariffPrice.Period.Value, (PeriodUnit)tariffPrice.Period.periodUnit);
                tariff.AddPriceItem(price, period);
            }

            foreach (var advancePrice in tariffDto.AdvancePrices)
            {
                Price price = new Price(advancePrice.Price.Value, advancePrice.Price.Currency);
                ProlongationPeriod period = new ProlongationPeriod(advancePrice.Period.Value, (PeriodUnit)advancePrice.Period.periodUnit);
                tariff.AddAdvancePriceItem(price, period);
            }

            //add included product
            foreach (var includedProduct in tariffDto.IncludedProducts)
            {
                Product product = await productRepository.GetProduct(includedProduct.ProductId);
                tariff.AddProduct(product, includedProduct.RelativeWeight);
            }

            //add product option
            foreach (var includedProductOption in tariffDto.IncludedProductOptions)
            {
                ProductOption productOption = await productOptionRepository.GetProductOption(includedProductOption.ProductOptionId);
                tariff.AddProductOption(productOption, includedProductOption.Quantity);
            }

            //add contractKindBindings
            foreach (var contractKindBinding in tariffDto.ContractKindBindings)
            {
                ContractKind contractkind = await contractKindRepository.GetContractKind(contractKindBinding.ContractKindId);
                tariff.AddAvailableContractKind(contractkind);
            }

            await tariffRepository.Add(tariff);

            return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody]TariffDto tariffDto)
        {
            Tariff tariff = await tariffRepository.GetTariff(tariffDto.Id);
            if (tariffDto.TestPeriod.Value != 0)
            {
                TariffTestPeriod testPeriod = new TariffTestPeriod(tariffDto.TestPeriod.Value, (TariffTestPeriodUnit)tariffDto.TestPeriod.Unit);
                tariff.SetTestPeriod(testPeriod);
            }
            else
            {
                tariff.SetTestPeriod(TariffTestPeriod.Empty());
            }
            tariff.SetName(tariffDto.Name);
            tariff.SetArchive(tariffDto.IsArchived);
            tariff.SetAccountingName(tariffDto.AccountingName);
            tariff.SetPaymentType((PaymentType)tariffDto.PaymentType);
            tariff.SetAwaitingPaymentStrategy(tariffDto.AwaitingPaymentStrategy);
            tariff.SetAccountingTariffId(tariffDto.AccountingTariffId);
            tariff.SetSettingsPresetId(tariffDto.SettingsPresetId);
            tariff.SetTermsOfUseId(tariffDto.TermsOfUseId);
            tariff.SetIsAcceptanceRequired(tariffDto.IsAcceptanceRequired);
            tariff.SetIsGradualFinishAvailable(tariff.IsGradualFinishAvailable);

            tariff.RemovePriceItems(tariffDto.Prices.ToTariffPrices());
            tariff.RemoveAdvancePrices(tariffDto.AdvancePrices.ToTariffAdvancePrices());
            tariff.RemoveIncludedProduct(tariffDto.IncludedProducts.Select(x => x.ProductId).ToList());
            tariff.RemoveIncludedProductOption(tariffDto.IncludedProductOptions.Select(x => x.ProductOptionId).ToList());
            tariff.RemoveContractKindBinding(tariffDto.ContractKindBindings.Select(x => x.ContractKindId).ToList());

            //add price 
            foreach (var item in tariffDto.Prices)
            {
                Price price = new Price(item.Price.Value, item.Price.Currency);
                ProlongationPeriod period = new ProlongationPeriod(item.Period.Value, (PeriodUnit)item.Period.periodUnit);
                if (tariff.Prices.FirstOrDefault(x => x.Period == period
                                                                    && x.Price.Currency == price.Currency) != null)
                {
                    tariff.ChangePriceItem(price, period);
                }
                else
                    tariff.AddPriceItem(price, period);
            }
            
            //advancePrice price 
            foreach (var item in tariffDto.AdvancePrices)
            {
                Price price = new Price(item.Price.Value, item.Price.Currency);
                ProlongationPeriod period = new ProlongationPeriod(item.Period.Value, 
                    (PeriodUnit)item.Period.periodUnit);
                if (tariff.AdvancePrices.FirstOrDefault(x => x.Period == period
                                                                    && x.Price.Currency == price.Currency) != null)
                {
                    tariff.ChangeAdvancePrice(price, period);
                }
                else
                    tariff.AddAdvancePriceItem(price, period);
            }

            //change included product
            foreach (var item in tariffDto.IncludedProducts)
            {
                Product product = await productRepository.GetProduct(item.ProductId);
                if (tariff.IncludedProducts.Select(x => x.ProductId).Contains(item.ProductId))
                {
                    var includedProduct = tariff.IncludedProducts.FirstOrDefault(x => x.ProductId == item.ProductId);
                    tariff.ChangeProduct(includedProduct, product, item.RelativeWeight);
                }
                else
                    tariff.AddProduct(product, item.RelativeWeight);
            }

            //change product option
            foreach (var item in tariffDto.IncludedProductOptions)
            {
                ProductOption productOption = await productOptionRepository.GetProductOption(item.ProductOptionId);
                if (tariff.IncludedProductOptions.Select(x => x.ProductOptionId).Contains(item.ProductOptionId))
                {
                    var includedProductOption = tariff.IncludedProductOptions.FirstOrDefault(x => x.ProductOptionId == item.ProductOptionId);
                    tariff.ChangeProductOption(includedProductOption, productOption, item.Quantity);
                }
                else
                    tariff.AddProductOption(productOption, item.Quantity);
            }

            //change contractKindBindings
            foreach (var item in tariffDto.ContractKindBindings)
            {
                ContractKind contractKind = await contractKindRepository.GetContractKind(item.ContractKindId);
                if (tariff.ContractKindBindings.Select(x => x.ContractKindId).Contains(item.ContractKindId))
                {
                    var contractKindBindings = tariff.ContractKindBindings.FirstOrDefault(x => x.ContractKindId == item.ContractKindId);
                    tariff.ChangeContractKind(contractKindBindings, contractKind);
                }
                else
                    tariff.AddAvailableContractKind(contractKind);
            }

            await tariffRepository.Update(tariff);


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
