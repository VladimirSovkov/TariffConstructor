using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TariffConstructor.AdminApi.Dto;
using TariffConstructor.Domain.TariffAggregate;
using TariffConstructor.AdminApi.Mappers.TariffAggregate;

namespace TariffConstructor.AdminApi.Controllers
{
    [Route("tariff")]
    public class TariffController : ControllerBase
    {

        private readonly ITariffRepository tariffRepository; 

        public TariffController(
            ITariffRepository tariffRepository)
        {
            this.tariffRepository = tariffRepository;
        }

        // GET: tariff/getTariffs
        //передовать IReadOnly or IReadOnlyCollection
        [HttpGet("getTariffs")]
        public async Task<IReadOnlyList<TariffDto>> Get()
        {
            List<Tariff> tariff = await tariffRepository.GetTariffsWithAcceptanceRequired();
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
