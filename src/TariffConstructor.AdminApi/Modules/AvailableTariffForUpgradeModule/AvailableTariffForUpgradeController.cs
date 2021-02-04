using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TariffConstructor.Domain.TariffModel;

namespace TariffConstructor.AdminApi.Modules.AvailableTariffForUpgradeModule
{
    [ApiController]
    [Route("availableTariffsForUpgrade")]
    public class AvailableTariffForUpgradeController : ControllerBase
    {
        private readonly IAvailableTariffForUpgradeRepository availableTariffForUpgradeRepository;

        public AvailableTariffForUpgradeController(IAvailableTariffForUpgradeRepository availableTariffForUpgradeRepository)
        {
            this.availableTariffForUpgradeRepository = availableTariffForUpgradeRepository;
        }

        [HttpGet("add")]
        public async Task<IActionResult> AddAvailableTariffForUpgrade([FromBody] AvailableTariffForUpgradeDto availableTariffForUpgradeDto)
        {

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAvailableTariffsForUpgrades()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAvailableTariffForUpgrade(int id)
        {

            return Ok();
        }

        [HttpDelete("")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok();

        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] AvailableTariffForUpgradeDto availableTariffForUpgradeDto)
        {
            return Ok();

        }

        [HttpGet("search")]
        public async Task<IActionResult> Search()
        {
            return Ok();
        }
    }
}
