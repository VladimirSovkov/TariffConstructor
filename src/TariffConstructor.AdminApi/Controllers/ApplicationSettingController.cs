using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TariffConstructor.AdminApi.Dto.ApplicationSetting;
using TariffConstructor.AdminApi.Mappers.ApplicationSettingMap;
using TariffConstructor.Domain.ApplicationSettingModel;
using TariffConstructor.Domain.PaginationPattern;
using TariffConstructor.Toolkit.Pagination;

namespace TariffConstructor.AdminApi.Controllers
{
    [Route("applicationSetting")]
    [ApiController]
    public class ApplicationSettingController : ControllerBase
    {
        private readonly IApplicationSettingRepository applicationSettingRepository;

        public ApplicationSettingController(IApplicationSettingRepository applicationSettingRepository)
        {
            this.applicationSettingRepository = applicationSettingRepository;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddApplicationSetting ([FromBody] ApplicationSettingDto applicationSettingDto)
        {
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
