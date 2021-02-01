using System.Collections.Generic;
using System.Threading.Tasks;
using TariffConstructor.Domain.SearchPattern;
using TariffConstructor.Toolkit.Abstractions;
using TariffConstructor.Toolkit.Search;

namespace TariffConstructor.Domain.TermsOfUseModel
{
    public interface ITermsOfUseRepository : IRepository<TermsOfUse>
    {
        Task<SearchResult<TermsOfUse>> Search(TermsOfUseSearchPattern searchPattern);
        Task<TermsOfUse> GetTermsOfUse( int termsOfUseId );
        Task<TermsOfUse> GetTermsOfUse(string publicId);
        Task<List<TermsOfUse>> GetTermsOfUses();
    }
}
