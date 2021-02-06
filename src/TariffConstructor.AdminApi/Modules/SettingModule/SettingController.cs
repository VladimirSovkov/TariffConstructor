using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TariffConstructor.Domain.SettingModel;
using TariffConstructor.Toolkit.Search;

namespace TariffConstructor.AdminApi.Modules.SettingModule
{
    [Route("setting")]
    [ApiController]
    public class SettingController : ControllerBase
    {
        private readonly ISettingRepository settingRepository;

        public SettingController(ISettingRepository settingRepository)
        {
            this.settingRepository = settingRepository;
        }

        [HttpPost("add")] 
        public async Task<IActionResult> AddSetting([FromBody] SettingDto settingDto)
        {
            Setting setting = new Setting((SettingType)settingDto.Type, 
                settingDto.Code, settingDto.Name, settingDto.IsComputing, settingDto.Description);
            await settingRepository.Add(setting);
            return Ok();
        }

        [HttpGet("getSetting")]
        public async Task<IActionResult> GetSetting(int id)
        {
            Setting setting = await settingRepository.GetSetting(id);
            if (setting == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Setting id == {id}. Not found!");
            }
            return Ok(setting.Map());
        }
            
        [HttpDelete("")]
        public async Task<IActionResult> Delete(int id)
        {
            await settingRepository.Delete(id);
            return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody]SettingDto settingDto)
        {
            Setting setting = await settingRepository.GetSetting(settingDto.Id);
            if (setting == null )
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Setting id == {settingDto.Id}. Not found!");
            }
            setting.SetCode(settingDto.Code);
            setting.SetDescription(settingDto.Description);
            setting.SetIsComputing(settingDto.IsComputing);
            setting.SetName(settingDto.Name);
            setting.SetType((SettingType)settingDto.Type);
            await settingRepository.Update(setting);
            return Ok();
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(int pageNumber, int onPage, string searchString)
        {
            var abc = new SettingSearchPattern
            {
                PageNumber = pageNumber,
                OnPage = onPage,
                SearchString = searchString
            };
            SearchResult<Setting> searchResult = await settingRepository.Search(abc);

            return Ok(new SearchResult<SettingDto>
            {
                Items = searchResult.Items.Map(),
                TotalCount = searchResult.TotalCount,
                FilteredCount = searchResult.FilteredCount
            });
        }

        [HttpGet("getSettings")]
        public async Task<IActionResult> GetSettings()
        {
            var settings = await settingRepository.GetSettings();
            return Ok(settings.Map());
        }

    }
}
