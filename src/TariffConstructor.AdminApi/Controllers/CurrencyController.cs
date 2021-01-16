using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TariffConstructor.AdminApi.Dto.Currency;
using TariffConstructor.AdminApi.Mappers.CurrencyMap;
using TariffConstructor.Domain.CurrencyModel;
using TariffConstructor.Domain.SearchPattern;
using TariffConstructor.Toolkit.Search;

namespace TariffConstructor.AdminApi.Controllers
{
    [Route("currency")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyRepository currencyRepository;

        public CurrencyController(ICurrencyRepository currencyRepository)
        {
            this.currencyRepository = currencyRepository;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CurrencyDto currencyDto)
        {
            Currency currency = new Currency(currencyDto.Code, currencyDto.Name);
            currency = await currencyRepository.Add(currency);
            return Ok(currency.Map());
        }

        [HttpGet("getCurrency")]
        public async Task<IActionResult> GetCurrency(int id)
        {
            Currency currency = await currencyRepository.GetCurrency(id);
            if (currency == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Currency id == {id}. Not found!");
            }
            return Ok(currency.Map());
        }

        [HttpDelete("")]
        public async Task<IActionResult> Delete(int id)
        {
            await currencyRepository.Delete(id);
            return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] CurrencyDto currencyDto)
        {
            Currency currency = await currencyRepository.GetCurrency(currencyDto.Id);
            if (currency == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Currency id == {currencyDto.Id}. Not found!");
            }
            currency.SetCode(currencyDto.Code);
            currency.SetName(currencyDto.Name);
            await currencyRepository.Update(currency);
            return Ok();
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(int pageNumber, int onPage, string searchString)
        {
            var abc = new CurrencySearchPattern();
            abc.PageNumber = pageNumber;
            abc.OnPage = onPage;
            abc.SearchString = searchString;
            SearchResult<Currency> searchResult = await currencyRepository.Search(abc);

            return Ok(new SearchResult<CurrencyDto>
            {
                Items = searchResult.Items.Map(),
                TotalCount = searchResult.TotalCount,
                FilteredCount = searchResult.FilteredCount
            });
        }

        [HttpGet("getCurrencies")]
        public async Task<IActionResult> GetCurrencies()
        {
            var currency = await currencyRepository.GetCurrencies();
            return Ok(currency.Map());
        }
    }
}
