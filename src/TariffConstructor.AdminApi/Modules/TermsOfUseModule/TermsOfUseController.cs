using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TariffConstructor.Domain.TariffModel;
using TariffConstructor.Domain.TermsOfUseModel;
using TariffConstructor.Toolkit.Abstractions;
using TariffConstructor.Toolkit.Search;

namespace TariffConstructor.AdminApi.Modules.TermsOfUseModule
{
    [Route("termsOfUses")]
    [ApiController]
    public class TermsOfUseController : ControllerBase
    {
        private readonly ITermsOfUseRepository termsOfUseRepository;
        private readonly ITariffRepository tariffRepository;
        private readonly IUnitOfWork unitOfWork;

        public TermsOfUseController(ITermsOfUseRepository termsOfUseRepository,
            ITariffRepository tariffRepository,
            IUnitOfWork unitOfWork)
        {
            this.termsOfUseRepository = termsOfUseRepository;
            this.tariffRepository = tariffRepository;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] TermsOfUseDto termsOfUseDto)
        {
            if (await termsOfUseRepository.GetTermsOfUse(termsOfUseDto.PublicId) != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"TermsOfUse with this PublicId == {termsOfUseDto.PublicId} already exists");
            }
            TermsOfUse termsOfUse = new TermsOfUse(termsOfUseDto.PublicId, termsOfUseDto.DocumentName);
            await termsOfUseRepository.Add(termsOfUse);
            await unitOfWork.SaveEntitiesAsync();

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTermsOfUse(int id)
        {
            TermsOfUse termsOfUse = await termsOfUseRepository.GetTermsOfUse(id);
            if (termsOfUse == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"TermsOfUse id == {id}. Not found!");
            }
            return Ok(termsOfUse.Map());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Tariff tariff = await tariffRepository.GeTariffFirstOrDefaulTermsOfUse(id);
            if (tariff != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"You cannot delete the terms of use, as they are used in the tariff == {tariff.Name}");
            }
            await termsOfUseRepository.Delete(id);
            await unitOfWork.SaveEntitiesAsync();
            return Ok();
        }

        [HttpPost("")]
        public async Task<IActionResult> Update([FromBody] TermsOfUseDto termsOfUseDto)
        {
            TermsOfUse termsOfUse = await termsOfUseRepository.GetTermsOfUse(termsOfUseDto.Id);
            if (termsOfUse == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"TermsOfUse id == {termsOfUseDto.Id}. Not found!");
            }
            if (termsOfUse.PublicId != termsOfUseDto.PublicId)
            {
                if (await termsOfUseRepository.GetTermsOfUse(termsOfUseDto.PublicId) != null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"TermsOfUse with this PublicId == {termsOfUseDto.PublicId} already exists");
                }
                termsOfUse.SetPublicId(termsOfUseDto.PublicId);
            }
            termsOfUse.SetDocumentName(termsOfUseDto.DocumentName);
            await termsOfUseRepository.Update(termsOfUse);
            await unitOfWork.SaveEntitiesAsync();
            return Ok();
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(int pageNumber, int onPage, string searchString)
        {
            var abc = new TermsOfUseSearchPattern
            {
                PageNumber = pageNumber,
                OnPage = onPage,
                SearchString = searchString
            };
            SearchResult<TermsOfUse> searchResult = await termsOfUseRepository.Search(abc);

            return Ok(new SearchResult<TermsOfUseDto>
            {
                Items = searchResult.Items.Map(),
                TotalCount = searchResult.TotalCount,
                FilteredCount = searchResult.FilteredCount
            });
        }

        [HttpGet("")]
        public async Task<IActionResult> GetSettings()
        {
            var termsOfUses = await termsOfUseRepository.GetTermsOfUses();
            return Ok(termsOfUses.Map());
        }
    }
}
