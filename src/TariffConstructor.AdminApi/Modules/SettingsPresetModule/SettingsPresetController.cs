using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using TariffConstructor.Domain.ApplicationSettingModel;
using TariffConstructor.Domain.BillingSettingModel;
using TariffConstructor.Domain.SettingModel;
using TariffConstructor.Domain.TariffModel;
using TariffConstructor.Toolkit.Search;

namespace TariffConstructor.AdminApi.Modules.SettingsPresetModule
{
    [Route("settingsPreset")]
    [ApiController]
    public class SettingsPresetController : ControllerBase
    {
        private readonly ISettingsPresetRepository settingsPresetRepository;
        private readonly ITariffRepository tariffRepository;


        public SettingsPresetController(ISettingsPresetRepository settingsPresetRepository,
            ITariffRepository tariffRepository)
        {
            this.settingsPresetRepository = settingsPresetRepository;
            this.tariffRepository = tariffRepository;
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

            await settingsPresetRepository.Add(settingPreset);
            return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] SettingsPresetDto settingsPresetDto)
        {
            SettingsPreset settingsPreset = await settingsPresetRepository.GetSettingsPreset(settingsPresetDto.Id);
            settingsPreset.SetName(settingsPresetDto.Name);
            settingsPreset.RemoveApplicationSettingsPresets(settingsPresetDto.ApplicationSettingPresets.Select(x => x.ApplicationSettingId).ToList());
            settingsPreset.RemoveBillingSettingPresets(settingsPresetDto.BillingSettingPresets.Select(x => x.BillingSettingId).ToList());
            foreach (var item in settingsPresetDto.ApplicationSettingPresets)
            {
                SettingPresetValue settingPresetValue = new SettingPresetValue(
                    item.Value.DefaultValue,
                    item.Value.MinValue,
                    item.Value.MaxValue
                );
                ApplicationSettingPreset applicationSettingPreset = new ApplicationSettingPreset(
                    item.SettingsPresetId,
                    item.ApplicationSettingId,
                    settingPresetValue,
                    item.IsRequired,
                    item.IsReadOnly,
                    item.IsHidden
                );

                if (settingsPreset.ApplicationSettingPresets.Select(x => x.ApplicationSettingId).Contains(item.ApplicationSettingId))
                    settingsPreset.ChangeApplicationSetting(applicationSettingPreset);
                else
                    settingsPreset.AddApplicationSettingPreset(applicationSettingPreset);
            }

            foreach (var item in settingsPresetDto.BillingSettingPresets)
            {
                SettingPresetValue settingPresetValue = new SettingPresetValue(
                    item.Value.DefaultValue,
                    item.Value.MinValue,
                    item.Value.MaxValue
                );
                BillingSettingPreset billingSettingPreset = new BillingSettingPreset(
                    item.SettingsPresetId,
                    item.BillingSettingId,
                    settingPresetValue,
                    item.IsRequired,
                    item.IsReadOnly,
                    item.IsHidden
                );

                if (settingsPreset.BillingSettingPresets.Select(x => x.BillingSettingId).Contains(item.BillingSettingId))
                    settingsPreset.ChangeBillingSettingPreset(billingSettingPreset);
                else
                    settingsPreset.AddBillingSettingPreset(billingSettingPreset);
            }

            await settingsPresetRepository.Update(settingsPreset);

            return Ok();
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(int pageNumber, int onPage, string searchString)
        {
            var searchPattern = new SettingsPresetSearchPattern
            {
                PageNumber = pageNumber,
                OnPage = onPage,
                SearchString = searchString
            };
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
            return Ok(settingsPreset.Map());
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetSettingsPresets()
        {
            var settingsPresets = await settingsPresetRepository.GetSettingsPresets();
            return Ok(settingsPresets);
        }

        [HttpDelete("")]
        public async Task<IActionResult> Delete(int id)
        {
            Tariff tariff = await tariffRepository.GeTariffFirstOrDefaultSettingPreset(id);
            if (tariff != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"You cannot delete the settings preset, as they are used in the tariff == {tariff.Name}");
            }
            await settingsPresetRepository.Delete(id);
            return Ok();
        }
    }
}
