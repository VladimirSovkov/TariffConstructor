using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TariffConstructor.AdminApi.Dto.ApplicationSetting;
using TariffConstructor.AdminApi.Mappers.ApplicationSettingMap;
using TariffConstructor.Domain.ApplicationModel;
using TariffConstructor.Domain.ApplicationSettingModel;
using TariffConstructor.Domain.PaginationPattern;
using TariffConstructor.Domain.SettingModel;
using TariffConstructor.Toolkit.Pagination;

namespace TariffConstructor.AdminApi.Controllers
{
    [Route("applicationSetting")]
    [ApiController]
    public class ApplicationSettingController : ControllerBase
    {
        private readonly IApplicationSettingRepository applicationSettingRepository;
        private readonly IApplicationRepository applicationRepository;
        private readonly ISettingRepository settingRepository;

        public ApplicationSettingController(IApplicationSettingRepository applicationSettingRepository
            , IApplicationRepository applicationRepository
            , ISettingRepository settingRepository)
        {
            this.applicationSettingRepository = applicationSettingRepository;
            this.applicationRepository = applicationRepository;
            this.settingRepository = settingRepository;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddApplicationSetting ([FromBody] ApplicationSettingDto applicationSettingDto)
        {
            if (await applicationSettingRepository.GetApplicationSetting(applicationSettingDto.ApplicationId, 
                applicationSettingDto.SettingId) != null)
            {
                Application application = await applicationRepository.GetApplication(applicationSettingDto.ApplicationId);
                Setting setting = await settingRepository.GetSetting(applicationSettingDto.SettingId);
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    $"ApplicationSetting with this Application == {application.Name} and" +
                    $" Setting  == {setting.Name} already exists");
            }
            ApplicationSetting applicationSetting = new ApplicationSetting(
                applicationSettingDto.ApplicationId
                , applicationSettingDto.SettingId);
            applicationSetting.SetDefaultValue(applicationSettingDto.DefaultValue);
            applicationSetting = await applicationSettingRepository.Add(applicationSetting);
            return Ok();
        }

        [HttpGet("getApplicationSetting")]
        public async Task<IActionResult> GetApplicationSetting(int id)
        {
            ApplicationSetting applicationSetting = await applicationSettingRepository.GetApplicationSetting(id);
            if (applicationSetting == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"ApplicationSetting id == {id}. Not found!");
            }
            return Ok(applicationSetting);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            List<ApplicationSetting> applicationSettings = await applicationSettingRepository.GetApplicationSettings();
            return Ok(applicationSettings);
        }

        [HttpDelete("")]
        public async Task<IActionResult> DeleteApplicationSetting(int id)
        {
            await applicationSettingRepository.Delete(id);
            return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateApplicationSetting([FromBody] ApplicationSettingDto applicationSettingDto)
        {
            ApplicationSetting applicationSetting = await applicationSettingRepository.GetApplicationSetting(applicationSettingDto.Id);
            if (applicationSetting == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"ApplicationSetting id == {applicationSettingDto.Id}. Not found!");
            }
            if (applicationSetting.ApplicationId != applicationSettingDto.ApplicationId &&
                applicationSetting.SettingId != applicationSettingDto.SettingId)
            {
                if (await applicationSettingRepository.GetApplicationSetting(applicationSettingDto.ApplicationId,
                applicationSettingDto.SettingId) != null)
                {
                    Application application = await applicationRepository.GetApplication(applicationSettingDto.ApplicationId);
                    Setting setting = await settingRepository.GetSetting(applicationSettingDto.SettingId);
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        $"ApplicationSetting with this Application == {application.Name} and" +
                        $" Setting  == {setting.Name} already exists");
                }
            }
            applicationSetting.SetSettingId(applicationSettingDto.SettingId);
            applicationSetting.SetApplicationId(applicationSettingDto.ApplicationId);
            applicationSetting.SetDefaultValue(applicationSettingDto.DefaultValue);
            await applicationSettingRepository.Update(applicationSetting);
            return Ok();
        }

        [HttpGet("pagination")]
        [ProducesResponseType(typeof(PaginationResult<ApplicationSettingDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> PaginationApplicationSetting(int pageNumber, int onPage)
        {
            var searchPattern = new ApplicationSettingPaginationPattern();
            searchPattern.PageNumber = pageNumber;
            searchPattern.OnPage = onPage;
            PaginationResult<ApplicationSetting> searchResult = await applicationSettingRepository.Pagination(searchPattern);

            return Ok(new PaginationResult<ApplicationSettingDto>
            {
                Items = searchResult.Items.Map(),
                TotalCount = searchResult.TotalCount,
            });
        }
    }
}
