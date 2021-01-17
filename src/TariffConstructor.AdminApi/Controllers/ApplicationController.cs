﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TariffConstructor.AdminApi.Dto.Application;
using TariffConstructor.AdminApi.Mappers.ApplicationMap;
using TariffConstructor.Domain.ApplicationModel;
using TariffConstructor.Domain.SearchPattern;
using TariffConstructor.Toolkit.Search;

namespace TariffConstructor.AdminApi.Controllers
{
    [Route("application")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationRepository applicationRepository;

        public ApplicationController(IApplicationRepository applicationRepository)
        {
            this.applicationRepository = applicationRepository;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] ApplicationDto applicationDto)
        {
            Application application = new Application(applicationDto.PublicId, applicationDto.Name);
            application = await applicationRepository.Add(application);
            return Ok(application.Map());
        }

        [HttpGet("getApplication")]
        public async Task<IActionResult> GetApplication(int id)
        {
            Application application = await applicationRepository.GetApplication(id);
            if (application == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Application id == {id}. Not found!");
            }
            return Ok(application.Map());
        }

        [HttpDelete("")]
        public async Task<IActionResult> Delete(int id)
        {
            await applicationRepository.Delete(id);
            return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] ApplicationDto applicationDto)
        {
            Application application = await applicationRepository.GetApplication(applicationDto.Id);
            if (application == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Application id == {applicationDto.Id}. Not found!");
            }
            application.SetPublicId(applicationDto.PublicId);
            application.SetName(applicationDto.Name);
            await applicationRepository.Update(application);
            return Ok();
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(int pageNumber, int onPage, string searchString)
        {
            var abc = new ApplicationSearchPattern();
            abc.PageNumber = pageNumber;
            abc.OnPage = onPage;
            abc.SearchString = searchString;
            SearchResult<Application> searchResult = await applicationRepository.Search(abc);

            return Ok(new SearchResult<ApplicationDto>
            {
                Items = searchResult.Items.Map(),
                TotalCount = searchResult.TotalCount,
                FilteredCount = searchResult.FilteredCount
            });
        }

        [HttpGet("getApplications")]
        public async Task<IActionResult> GetSettings()
        {
            var applications = await applicationRepository.GetApplications();
            return Ok(applications.Map());
        }
    }
}