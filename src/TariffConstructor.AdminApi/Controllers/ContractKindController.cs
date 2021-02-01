using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TariffConstructor.AdminApi.Dto.ContractKind;
using TariffConstructor.AdminApi.Mappers.ContractKindMap;
using TariffConstructor.Domain.ContractKindModel;
using TariffConstructor.Domain.SearchPattern;
using TariffConstructor.Toolkit.Search;

namespace TariffConstructor.AdminApi.Controllers
{
    [Route("contractKind")]
    [ApiController]
    public class ContractKindController : ControllerBase
    {
        private readonly IContractKindRepository contractKindRepository;

        public ContractKindController(IContractKindRepository contractKindRepository)
        {
            this.contractKindRepository = contractKindRepository;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] ContractKindDto contractKindDto)
        {
            if (await contractKindRepository.GetContractKind(contractKindDto.PublicId) != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"ContractKind with this PublicId == {contractKindDto.PublicId} already exists");
            }
            ContractKind contractKind = new ContractKind(contractKindDto.PublicId, contractKindDto.Name);
            contractKind = await contractKindRepository.Add(contractKind);
            return Ok(contractKind.Map());
        }

        [HttpPost("update")]
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
            return Ok();
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetApplication(int id)
        {
            ContractKind application = await contractKindRepository.GetContractKind(id);
            if (application == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"ContractKind id == {id}. Not found!");
            }
            return Ok(application.Map());
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetSettings()
        {
            var contractKinds = await contractKindRepository.GetContractKinds();
            return Ok(contractKinds.Map());
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(int pageNumber, int onPage, string searchString)
        {
            var abc = new ContractKindSearchPattern();
            abc.PageNumber = pageNumber;
            abc.OnPage = onPage;
            abc.SearchString = searchString;
            SearchResult<ContractKind> searchResult = await contractKindRepository.Search(abc);

            return Ok(new SearchResult<ContractKindDto>
            {
                Items = searchResult.Items.Map(),
                TotalCount = searchResult.TotalCount,
                FilteredCount = searchResult.FilteredCount
            });
        }

        [HttpDelete("")]
        public async Task<IActionResult> Delete(int id)
        {
            await contractKindRepository.Delete(id);
            return Ok();
        }
    }
}
