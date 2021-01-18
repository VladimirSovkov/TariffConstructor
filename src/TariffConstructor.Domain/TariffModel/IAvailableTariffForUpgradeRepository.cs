using System.Collections.Generic;
using System.Threading.Tasks;
using TariffConstructor.Domain.SearchPattern;
using TariffConstructor.Toolkit.Abstractions;
using TariffConstructor.Toolkit.Search;

namespace TariffConstructor.Domain.TariffModel
{
    public interface IAvailableTariffForUpgradeRepository : IRepository<AvailableTariffForUpgrade>
    {
        Task<AvailableTariffForUpgrade> GetAvailableTariffForUpgrade(int id);
        Task<List<AvailableTariffForUpgrade>> GetAvailableTariffForUpgrades();
        Task<SearchResult<AvailableTariffForUpgrade>> Serach(AvailableTariffForUpgradeSearchPattern searchPattern);
    }
}
