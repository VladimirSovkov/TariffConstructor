using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TariffConstructor.Domain.ApplicationModel;
using TariffConstructor.Toolkit.Abstractions;
using TariffConstructor.Toolkit.Search;

namespace TariffConstructor.AdminApi.Modules.ApplicationModule
{
    [Route("applications")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationRepository applicationRepository;
        IUnitOfWork unitOfWork;

        public ApplicationController(IApplicationRepository applicationRepository,
            IUnitOfWork unitOfWork)
        {
            this.applicationRepository = applicationRepository;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] ApplicationReadOnlyDto applicationDto)
        {
            if (await applicationRepository.GetApplication(applicationDto.PublicId) != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"application with this PublicId == {applicationDto.PublicId} already exists");
            }
            Application application = new Application(applicationDto.PublicId, applicationDto.Name);
            await applicationRepository.Add(application);
            await unitOfWork.SaveEntitiesAsync();
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetApplication(int id)
        {
            Application application = await applicationRepository.GetApplication(id);
            if (application == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Application id == {id}. Not found!");
            }
            return Ok(application.Map());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await applicationRepository.Delete(id);
            return Ok();
        }

        [HttpPost("")]
        public async Task<IActionResult> Update([FromBody] ApplicationDto applicationDto)
        {
            Application application = await applicationRepository.GetApplication(applicationDto.Id);
            if (application == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Application id == {applicationDto.Id}. Not found!");
            }
            if (application.PublicId != applicationDto.PublicId)
            {
                if (await applicationRepository.GetApplication(applicationDto.PublicId) != null) 
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"application with this PublicId == {applicationDto.PublicId} already exists");
                }
                application.SetPublicId(applicationDto.PublicId);
            }
            application.SetName(applicationDto.Name);
            await applicationRepository.Update(application);

            return Ok();
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(int pageNumber, int onPage, string searchString)
        {
            var abc = new ApplicationSearchPattern
            {
                PageNumber = pageNumber,
                OnPage = onPage,
                SearchString = searchString
            };
            SearchResult<Application> searchResult = await applicationRepository.Search(abc);

            return Ok(new SearchResult<ApplicationDto>
            {
                Items = searchResult.Items.Map(),
                TotalCount = searchResult.TotalCount,
                FilteredCount = searchResult.FilteredCount
            });
        }

        [HttpGet("")]
        public async Task<IActionResult> GetSettings()
        {
            var applications = await applicationRepository.GetApplications();
            return Ok(applications.Map());
        }
    }
}
