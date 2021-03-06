﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TariffConstructor.Domain.ApplicationModel;
using TariffConstructor.Domain.ApplicationSettingModel;
using TariffConstructor.Domain.SettingModel;
using TariffConstructor.Toolkit.Abstractions;
using TariffConstructor.Toolkit.Pagination;

namespace TariffConstructor.AdminApi.Modules.ApplicationSettingModule
{
    [Route("applicationSettings")]
    [ApiController]
    public class ApplicationSettingController : ControllerBase
    {
        private readonly IApplicationSettingRepository applicationSettingRepository;
        private readonly IApplicationRepository applicationRepository;
        private readonly ISettingRepository settingRepository;
        private readonly IUnitOfWork unitOfWork;


        public ApplicationSettingController(IApplicationSettingRepository applicationSettingRepository, 
            IApplicationRepository applicationRepository, 
            ISettingRepository settingRepository,
            IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
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
            await applicationSettingRepository.Add(applicationSetting);
            await unitOfWork.SaveEntitiesAsync();

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetApplicationSetting(int id)
        {
            ApplicationSetting applicationSetting = await applicationSettingRepository.GetApplicationSetting(id);
            if (applicationSetting == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"ApplicationSetting id == {id}. Not found!");
            }
            return Ok(applicationSetting);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            List<ApplicationSetting> applicationSettings = await applicationSettingRepository.GetApplicationSettings();
            return Ok(applicationSettings);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplicationSetting(int id)
        {
            await applicationSettingRepository.Delete(id);
            await unitOfWork.SaveEntitiesAsync();

            return Ok();
        }

        [HttpPost("")]
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
            await unitOfWork.SaveEntitiesAsync();

            return Ok();
        }

        [HttpGet("pagination")]
        [ProducesResponseType(typeof(PaginationResult<ApplicationSettingDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> PaginationApplicationSetting(int pageNumber, int onPage)
        {
            var searchPattern = new ApplicationSettingPaginationPattern
            {
                PageNumber = pageNumber,
                OnPage = onPage
            };
            PaginationResult<ApplicationSetting> searchResult = await applicationSettingRepository.Pagination(searchPattern);

            return Ok(new PaginationResult<ApplicationSettingDto>
            {
                Items = searchResult.Items.Map(),
                TotalCount = searchResult.TotalCount,
            });
        }
    }
}
