using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TariffConstructor.Domain.PaginationPattern;
using TariffConstructor.Domain.TariffModel;
using TariffConstructor.Toolkit.Abstractions;
using TariffConstructor.Toolkit.Pagination;

namespace TariffConstructor.AdminApi.Modules.AvailableTariffForUpgradeModule
{
    [ApiController]
    [Route("availableTariffsForUpgrade")]
    public class AvailableTariffForUpgradeController : ControllerBase
    {
        private readonly IAvailableTariffForUpgradeRepository availableTariffForUpgradeRepository;
        private readonly IUnitOfWork unitOfWork;

        public AvailableTariffForUpgradeController(IAvailableTariffForUpgradeRepository availableTariffForUpgradeRepository,
            IUnitOfWork unitOfWork)
        {
            this.availableTariffForUpgradeRepository = availableTariffForUpgradeRepository;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("add")]
        public async Task<IActionResult> AddAvailableTariffForUpgrade([FromBody] AvailableTariffForUpgradeDto availableTariffForUpgradeDto)
        {
            AvailableTariffForUpgrade availableTariffForUpgrade = new AvailableTariffForUpgrade(
                availableTariffForUpgradeDto.FromTariffId,
                availableTariffForUpgradeDto.ToTariffId);
            await availableTariffForUpgradeRepository.Add(availableTariffForUpgrade);
            await unitOfWork.SaveEntitiesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAvailableTariffsForUpgrades()
        {
            var availableTariffsForUpgrades = await availableTariffForUpgradeRepository.GetAvailableTariffForUpgrades();
            return Ok(availableTariffsForUpgrades.Map());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAvailableTariffForUpgrade(int id)
        {
            AvailableTariffForUpgrade availableTariffForUpgrade = await availableTariffForUpgradeRepository.GetAvailableTariffForUpgrade(id);
            if (availableTariffForUpgrade == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"AvailableTariffForUpgrade id == {id}. Not found!");
            }
            return Ok(availableTariffForUpgrade.Map());
        }

        [HttpDelete("")]
        public async Task<IActionResult> Delete(int id)
        {
            await availableTariffForUpgradeRepository.Delete(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] AvailableTariffForUpgradeDto availableTariffForUpgradeDto)
        {
            AvailableTariffForUpgrade availableTariffForUpgrade = await availableTariffForUpgradeRepository.GetAvailableTariffForUpgrade(availableTariffForUpgradeDto.Id);
            if (availableTariffForUpgrade == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"AvailableTariffForUpgrade id == {availableTariffForUpgradeDto.Id}. Not found!");
            }
            availableTariffForUpgrade.SetFromTariffId(availableTariffForUpgradeDto.FromTariffId);
            availableTariffForUpgrade.SetToTariffId(availableTariffForUpgradeDto.ToTariffId);
            await availableTariffForUpgradeRepository.Update(availableTariffForUpgrade);

            await unitOfWork.SaveEntitiesAsync();
            return Ok();
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(int pageNumber, int onPage)
        {
            var paginationPattern = new AvailableTariffForUpgradePaginationPattern();
            paginationPattern.PageNumber = pageNumber;
            paginationPattern.OnPage = onPage;
            PaginationResult<AvailableTariffForUpgrade> searchResult = await availableTariffForUpgradeRepository.Serach(paginationPattern);

            return Ok(new PaginationResult<AvailableTariffForUpgradeDto>
            {
                Items = searchResult.Items.Map(),
                TotalCount = searchResult.TotalCount,
            });
        }
    }
}
