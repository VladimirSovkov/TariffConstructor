using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TariffConstructor.AdminApi.Dto;
using TariffConstructor.Domain.TariffAggregate;
using TariffConstructor.AdminApi.Mappers;
using TariffConstructor.AdminApi.Mappers.TariffAggregate;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TariffConstructor.AdminApi.Controllers
{
    [Route("tariff")]
    public class TariffController : ControllerBase
    {

        private readonly ITariffRepository _tariff;

        public TariffController(
            ITariffRepository tariff)
        {
            _tariff = tariff;
        }

        // GET: tariff/getTariffs
        [HttpGet("getTariffs")]
        public async Task<List<TariffDto>> Get()
        {
            List<Tariff> tariff = await _tariff.GetTariffsWithAcceptanceRequired();
            return tariff.Map();
        }

        // POST api/<TariffController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
