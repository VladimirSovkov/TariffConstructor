using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TariffConstructor.Domain.CurrencyModel;
using TariffConstructor.Toolkit.Abstractions;
using TariffConstructor.Toolkit.Search;

namespace TariffConstructor.AdminApi.Modules.CurrencyModule
{
    [Route("currencies")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyRepository currencyRepository;
        private readonly IUnitOfWork unitOfWork;

        public CurrencyController(ICurrencyRepository currencyRepository,
            IUnitOfWork unitOfWork)
        {
            this.currencyRepository = currencyRepository;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CurrencyDto currencyDto)
        {
            if (await currencyRepository.GetCurrencyByCode(currencyDto.Code) != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Currency with this PublicId == {currencyDto.Code} already exists");
            }
            if (await currencyRepository.GetCurrency(currencyDto.Name) != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Currency with this Name == {currencyDto.Name} already exists");
            }
            Currency currency = new Currency(currencyDto.Code, currencyDto.Name);
            await currencyRepository.Add(currency);
            await unitOfWork.SaveEntitiesAsync();
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCurrency(int id)
        {
            Currency currency = await currencyRepository.GetCurrency(id);
            if (currency == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Currency id == {id}. Not found!");
            }
            return Ok(currency.Map());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await currencyRepository.Delete(id);
            await unitOfWork.SaveEntitiesAsync();
            return Ok();
        }

        [HttpPost("")]
        public async Task<IActionResult> Update([FromBody] CurrencyDto currencyDto)
        {
            Currency currency = await currencyRepository.GetCurrency(currencyDto.Id);
            if (currency == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Currency id == {currencyDto.Id}. Not found!");
            }
            if (currency.Code != currencyDto.Code)
            {
                if (await currencyRepository.GetCurrencyByCode(currencyDto.Code) != null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Currency with this Name == {currencyDto.Code} already exists");
                }

                currency.SetCode(currencyDto.Code);
            }

            if (currency.Name != currencyDto.Name)
            {
                if (await currencyRepository.GetCurrency(currencyDto.Name) != null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Currency with this PublicId == {currencyDto.Name} already exists");
                }
                currency.SetName(currencyDto.Name);
            }

            await currencyRepository.Update(currency);
            await unitOfWork.SaveEntitiesAsync();
            return Ok();
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(int pageNumber, int onPage, string searchString)
        {
            var abc = new CurrencySearchPattern
            {
                PageNumber = pageNumber,
                OnPage = onPage,
                SearchString = searchString
            };
            SearchResult<Currency> searchResult = await currencyRepository.Search(abc);

            return Ok(new SearchResult<CurrencyDto>
            {
                Items = searchResult.Items.Map(),
                TotalCount = searchResult.TotalCount,
                FilteredCount = searchResult.FilteredCount
            });
        }

        [HttpGet("")]
        public async Task<IActionResult> GetCurrencies()
        {
            var currency = await currencyRepository.GetCurrencies();
            return Ok(currency.Map());
        }
    }
}
