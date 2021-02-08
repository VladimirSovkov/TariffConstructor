using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TariffConstructor.Domain.SettingModel;
using TariffConstructor.Toolkit.Abstractions;
using TariffConstructor.Toolkit.Search;

namespace TariffConstructor.AdminApi.Modules.SettingModule
{
    [Route("settings")]
    [ApiController]
    public class SettingController : ControllerBase
    {
        private readonly ISettingRepository settingRepository;
        private readonly IUnitOfWork unitOfWork;

        public SettingController(ISettingRepository settingRepository,
            IUnitOfWork unitOfWork)
        {
            this.settingRepository = settingRepository;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost("add")] 
        public async Task<IActionResult> AddSetting([FromBody] SettingDto settingDto)
        {
            Setting setting = new Setting((SettingType)settingDto.Type, 
                settingDto.Code, settingDto.Name, settingDto.IsComputing, settingDto.Description);
            await settingRepository.Add(setting);
            await unitOfWork.SaveEntitiesAsync();
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSetting(int id)
        {
            Setting setting = await settingRepository.GetSetting(id);
            if (setting == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Setting id == {id}. Not found!");
            }
            return Ok(setting.Map());
        }
            
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await settingRepository.Delete(id);
            await unitOfWork.SaveEntitiesAsync();
            return Ok();
        }

        [HttpPost("")]
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
            await unitOfWork.SaveEntitiesAsync();
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

        [HttpGet("")]
        public async Task<IActionResult> GetSettings()
        {
            var settings = await settingRepository.GetSettings();
            return Ok(settings.Map());
        }

    }
}
