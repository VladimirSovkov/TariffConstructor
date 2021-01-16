using System.Collections.Generic;
using System.Threading.Tasks;
using TariffConstructor.Domain.SearchPattern;
using TariffConstructor.Toolkit.Abstractions;
using TariffConstructor.Toolkit.Search;

namespace TariffConstructor.Domain.CurrencyModel
{
    public interface ICurrencyRepository : IRepository<Currency>
    {
        Task<List<Currency>> GetCurrencies();
        Task<Currency> GetCurrency(int id);
        Task<SearchResult<Currency>> Search(CurrencySearchPattern searchPattern);
    }
}
