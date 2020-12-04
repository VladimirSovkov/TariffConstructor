using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TariffConstructor.AdminApi.Dto;
using TariffConstructor.AdminApi.Mappers.TariffAggregate;
using TariffConstructor.Domain.ContractModel;
using TariffConstructor.Domain.TariffAggregate;
using TariffConstructor.Domain.TariffAggregate.Toolkit;
using TariffConstructor.Domain.ValueObjects;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.Interface;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ObjectTests.Interface;
using TariffConstructor.Toolkit.Search;

namespace TariffConstructor.AdminApi.Controllers
{
    [Route("test")]
    public class TestController : Controller
    {
        private readonly ITariffRepository _tariffTestPeriod;

        public TestController(
            ITariffRepository tariffRepository
            )
        {
            _tariffTestPeriod = tariffRepository;
        }

        [HttpPost("post")]
        public void AddTariff([FromBody]TariffLoadParameters parameters) 
        {
            var abc = parameters;
            PaymentType py = (PaymentType)Convert.ToInt32(parameters.PaymentType);
            Tariff tariff = new Tariff(parameters.Name, py);
            tariff.SetAccountingTariffId(parameters.AccountingTariffId);
            tariff.SetAwaitingPaymentStrategy(parameters.AwaitingPaymentStrategy);
            tariff.SetSettingsPresetId(parameters.SettingsPresetId);
            tariff.SetTermsOfUseId(parameters.TermsOfUseId);
            if (parameters.IsArchived)
            {
                tariff.Archive();
            }

            tariff.AddTestPeriod(new TariffTestPeriod(parameters.Value, (TariffTestPeriodUnit)Convert.ToInt32(parameters.Unit)));
            _tariffTestPeriod.AddTariff(tariff);
        }

        [HttpGet("paginator")]
        public async Task<IReadOnlyList<TariffDto>> GetTariffs()
        {
            TariffPaginator abc = await _tariffTestPeriod.GetTariffs(5, 2);
            IReadOnlyList<TariffDto> tariffs = abc.Tariffs.Map();
            return tariffs;
        }

        [HttpGet("search")]
        [ProducesResponseType(typeof(SearchResult<TariffDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int pageNumber, int onPage, string searchString)
        {
            var abc = new ContractSearchPattern();
            abc.PageNumber = pageNumber;
            abc.OnPage = onPage;
            abc.SearchString = searchString;
            SearchResult<Tariff> searchResult = await _tariffTestPeriod.GetFoundRates(abc);

            return Ok(new SearchResult<TariffDto>
            {
                Items = searchResult.Items.Map(),
                TotalCount = searchResult.TotalCount,
                FilteredCount = searchResult.FilteredCount
            }); 
        }
    }
}
