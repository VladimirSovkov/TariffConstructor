using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TariffConstructor.Domain.BillingSettingModel;
using TariffConstructor.Toolkit.Pagination;

namespace TariffConstructor.AdminApi.Modules.BillingSettingModule
{
    [Route("billingSettings")]
    [ApiController]
    public class BillingSettingController : ControllerBase
    {
        private readonly IBillingSettingRepository billingSettingRepository;

        public BillingSettingController(IBillingSettingRepository billingSettingRepository)
        {
            this.billingSettingRepository = billingSettingRepository;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] BillingSettingDto billingSettingDto)
        {
            BillingSetting billingSetting = new BillingSetting(billingSettingDto.SettingId);
            await billingSettingRepository.Add(billingSetting);
            return Ok();
        }

        [HttpPost("")]
        public async Task<IActionResult> Update([FromBody] BillingSettingDto billingSettingDto)
        {
            BillingSetting billingSetting = await billingSettingRepository.GetBillingSetting(billingSettingDto.Id);
            if (billingSetting == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"BillingSetting id == {billingSettingDto.Id}. Not found!");
            }
            billingSetting.SetSetting(billingSettingDto.SettingId);
            await billingSettingRepository.Update(billingSetting);
            return Ok();
        }

        [HttpGet("pagination")]
        [ProducesResponseType(typeof(PaginationResult<BillingSettingDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Pagination(int pageNumber, int onPage)
        {
            var searchPattern = new BillingSettingPaginationPattern();
            searchPattern.PageNumber = pageNumber;
            searchPattern.OnPage = onPage;
            PaginationResult<BillingSetting> searchResult = await billingSettingRepository.Pagination(searchPattern);

            return Ok(new PaginationResult<BillingSettingDto>
            {
                Items = searchResult.Items.Map(),
                TotalCount = searchResult.TotalCount,
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSetting(int id)
        {
            BillingSetting billingSetting = await billingSettingRepository.GetBillingSetting(id);
            if (billingSetting == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"BillingSetting id == {id}. Not found!");
            }
            return Ok(billingSetting.Map());
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            IReadOnlyList<BillingSetting> billingSettings = await billingSettingRepository.GetBillingSettings();
            return Ok(billingSettings);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await billingSettingRepository.Delete(id);
            return Ok();
        }
    }
}
