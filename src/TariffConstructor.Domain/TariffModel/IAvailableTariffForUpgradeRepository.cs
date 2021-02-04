using System.Collections.Generic;
using System.Threading.Tasks;
using TariffConstructor.Domain.SearchPattern;
using TariffConstructor.Toolkit.Abstractions;
using TariffConstructor.Toolkit.Pagination;

namespace TariffConstructor.Domain.TariffModel
{
    public interface IAvailableTariffForUpgradeRepository : IRepository<AvailableTariffForUpgrade>
    {
        Task<AvailableTariffForUpgrade> GetAvailableTariffForUpgrade(int id);
        Task<List<AvailableTariffForUpgrade>> GetAvailableTariffForUpgrades();
        Task<PaginationResult<AvailableTariffForUpgrade>> Serach(AvailableTariffForUpgradeSearchPattern searchPattern);
    }
}
