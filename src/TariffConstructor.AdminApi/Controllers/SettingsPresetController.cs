using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TariffConstructor.AdminApi.Dto.SettingDto;
using TariffConstructor.AdminApi.Mappers.SettingMap;
using TariffConstructor.Domain.ApplicationSettingAggregate;
using TariffConstructor.Domain.BillingSettingAggregate;
using TariffConstructor.Domain.SearchPattern;
using TariffConstructor.Domain.SettingAggregate;
using TariffConstructor.Toolkit.Search;

namespace TariffConstructor.AdminApi.Controllers
{
    [Route("settingsPreset")]
    [ApiController]
    public class SettingsPresetController : ControllerBase
    {
        private readonly ISettingsPresetRepository settingsPresetRepository;

        public SettingsPresetController(ISettingsPresetRepository settingsPresetRepository)
        {
            this.settingsPresetRepository = settingsPresetRepository;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] SettingsPresetDto settingsPresetDto)
        {
            SettingsPreset settingPreset = new SettingsPreset(settingsPresetDto.Name);
            foreach (var billingSettingPresetDto in settingsPresetDto.BillingSettingPresets)
            {
                SettingPresetValue settingPresetValue = new SettingPresetValue(
                    billingSettingPresetDto.Value.DefaultValue,
                    billingSettingPresetDto.Value.MinValue,
                    billingSettingPresetDto.Value.MaxValue
                );
                BillingSettingPreset billingSettingPreset = new BillingSettingPreset(
                        billingSettingPresetDto.SettingsPresetId,
                        billingSettingPresetDto.BillingSettingId,
                        settingPresetValue,
                        billingSettingPresetDto.IsRequired,
                        billingSettingPresetDto.IsReadOnly,
                        billingSettingPresetDto.IsHidden
                );
                settingPreset.AddBillingSettingPreset(billingSettingPreset);
            }

            foreach (var ApplicationSettingPresetDto in settingsPresetDto.ApplicationSettingPresets)
            {
                SettingPresetValue settingPresetValue = new SettingPresetValue(
                   ApplicationSettingPresetDto.Value.DefaultValue,
                   ApplicationSettingPresetDto.Value.MinValue,
                   ApplicationSettingPresetDto.Value.MaxValue
                );
                ApplicationSettingPreset applicationSettingPreset = new ApplicationSettingPreset(
                    ApplicationSettingPresetDto.SettingsPresetId,
                    ApplicationSettingPresetDto.ApplicationSettingId,
                    settingPresetValue,
                    ApplicationSettingPresetDto.IsRequired,
                    ApplicationSettingPresetDto.IsReadOnly,
                    ApplicationSettingPresetDto.IsHidden
                );
                settingPreset.AddApplicationSettingPreset(applicationSettingPreset);
            }

            settingPreset = await settingsPresetRepository.Add(settingPreset);
            return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] SettingsPresetDto settingsPresetDto)
        {
            return Ok();
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(int pageNumber, int onPage, string searchString)
        {
            var searchPattern = new SettingsPresetSearchPattern();
            searchPattern.PageNumber = pageNumber;
            searchPattern.OnPage = onPage;
            searchPattern.SearchString = searchString;
            SearchResult<SettingsPreset> searchResult = await settingsPresetRepository.Search(searchPattern);

            return Ok(new SearchResult<SettingsPresetDto>
            {
                Items = searchResult.Items.Map(),
                TotalCount = searchResult.TotalCount,
                FilteredCount = searchResult.FilteredCount
            });
        }

        [HttpGet("")]
        public async Task<IActionResult> GetSettingPreset(int id)
        {
            SettingsPreset settingsPreset = await settingsPresetRepository.GetSettingsPreset(id);
            if (settingsPreset == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Setting id == {id}. Not found!");
            }
            return Ok(settingsPreset);
        }

        [HttpDelete("")]
        public async Task<IActionResult> Delete(int id)
        {
            await settingsPresetRepository.Delete(id);
            return Ok();
        }
    }
}
