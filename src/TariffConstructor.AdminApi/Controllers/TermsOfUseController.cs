using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TariffConstructor.AdminApi.Dto.TermsOfUse;
using TariffConstructor.AdminApi.Mappers.TermsOfUseMap;
using TariffConstructor.Domain.SearchPattern;
using TariffConstructor.Domain.TermsOfUseAggregate;
using TariffConstructor.Toolkit.Search;

namespace TariffConstructor.AdminApi.Controllers
{
    [Route("termsOfUse")]
    [ApiController]
    public class TermsOfUseController : ControllerBase
    {
        private readonly ITermsOfUseRepository termsOfUseRepository;

        public TermsOfUseController(ITermsOfUseRepository termsOfUseRepository)
        {
            this.termsOfUseRepository = termsOfUseRepository;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] TermsOfUseDto termsOfUseDto)
        {
            TermsOfUse termsOfUse = new TermsOfUse(termsOfUseDto.PublicId, termsOfUseDto.DocumentName);
            termsOfUse = await termsOfUseRepository.Add(termsOfUse);

            return Ok(termsOfUse.Map());
        }

        [HttpGet("getTermsOfUse")]
        public async Task<IActionResult> GetTermsOfUse(int id)
        {
            TermsOfUse termsOfUse = await termsOfUseRepository.GetTermsOfUse(id);
            if (termsOfUse == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"TermsOfUse id == {id}. Not found!");
            }
            return Ok(termsOfUse.Map());
        }

        [HttpDelete("")]
        public async Task<IActionResult> Delete(int id)
        {
            await termsOfUseRepository.Delete(id);
            return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] TermsOfUseDto termsOfUseDto)
        {
            TermsOfUse termsOfUse = await termsOfUseRepository.GetTermsOfUse(termsOfUseDto.Id);
            if (termsOfUse == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"TermsOfUse id == {termsOfUseDto.Id}. Not found!");
            }
            termsOfUse.SetPublicId(termsOfUseDto.PublicId);
            termsOfUse.SetDocumentName(termsOfUseDto.DocumentName);
            await termsOfUseRepository.Update(termsOfUse);
            return Ok();
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(int pageNumber, int onPage, string searchString)
        {
            var abc = new TermsOfUseSearchPattern();
            abc.PageNumber = pageNumber;
            abc.OnPage = onPage;
            abc.SearchString = searchString;
            SearchResult<TermsOfUse> searchResult = await termsOfUseRepository.Search(abc);

            return Ok(new SearchResult<TermsOfUseDto>
            {
                Items = searchResult.Items.Map(),
                TotalCount = searchResult.TotalCount,
                FilteredCount = searchResult.FilteredCount
            });
        }

        [HttpGet("getTermsOfUses")]
        public async Task<IActionResult> GetSettings()
        {
            var termsOfUses = await termsOfUseRepository.GetTermsOfUses();
            return Ok(termsOfUses.Map());
        }
    }
}
