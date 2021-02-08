using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TariffConstructor.Domain.ContractKindModel;
using TariffConstructor.Toolkit.Abstractions;
using TariffConstructor.Toolkit.Search;

namespace TariffConstructor.AdminApi.Modules.ContractKindModule
{
    [Route("contractKinds")]
    [ApiController]
    public class ContractKindController : ControllerBase
    {
        private readonly IContractKindRepository contractKindRepository;
        private readonly IUnitOfWork unitOfWork;
        
        public ContractKindController(IContractKindRepository contractKindRepository,
            IUnitOfWork unitOfWork)
        {
            this.contractKindRepository = contractKindRepository;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] ContractKindDto contractKindDto)
        {
            if (await contractKindRepository.GetContractKind(contractKindDto.PublicId) != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"ContractKind with this PublicId == {contractKindDto.PublicId} already exists");
            }
            ContractKind contractKind = new ContractKind(contractKindDto.PublicId, contractKindDto.Name);
            await contractKindRepository.Add(contractKind);
            await unitOfWork.SaveEntitiesAsync();
            return Ok();
        }

        [HttpPost("")]
        public async Task<IActionResult> Update([FromBody] ContractKindDto contractKindDto)
        {
            ContractKind contractKind = await contractKindRepository.GetContractKind(contractKindDto.Id);
            if (contractKind == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"ContractKind id == {contractKindDto.Id}. Not found!");
            }
            if (contractKind.PublicId != contractKindDto.PublicId)
            {
                if (await contractKindRepository.GetContractKind(contractKindDto.PublicId) != null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"ContractKind with this PublicId == {contractKindDto.PublicId} already exists");
                }
                contractKind.SetPublicId(contractKindDto.PublicId);
            }
            contractKind.SetPublicId(contractKindDto.PublicId);
            contractKind.SetName(contractKindDto.Name);
            await contractKindRepository.Update(contractKind);
            await unitOfWork.SaveEntitiesAsync();
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetApplication(int id)
        {
            ContractKind application = await contractKindRepository.GetContractKind(id);
            if (application == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"ContractKind id == {id}. Not found!");
            }
            return Ok(application.Map());
        }

        [HttpGet("")]
        public async Task<IActionResult> GetSettings()
        {
            var contractKinds = await contractKindRepository.GetContractKinds();
            return Ok(contractKinds.Map());
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(int pageNumber, int onPage, string searchString)
        {
            var abc = new ContractKindSearchPattern
            {
                PageNumber = pageNumber,
                OnPage = onPage,
                SearchString = searchString
            };
            SearchResult<ContractKind> searchResult = await contractKindRepository.Search(abc);

            return Ok(new SearchResult<ContractKindDto>
            {
                Items = searchResult.Items.Map(),
                TotalCount = searchResult.TotalCount,
                FilteredCount = searchResult.FilteredCount
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await contractKindRepository.Delete(id);
            await unitOfWork.SaveEntitiesAsync();
            return Ok();
        }
    }
}
