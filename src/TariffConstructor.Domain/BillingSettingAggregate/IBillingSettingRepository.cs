using System.Collections.Generic;
using System.Threading.Tasks;
using TariffConstructor.Domain.PaginationPattern;
using TariffConstructor.Toolkit.Abstractions;
using TariffConstructor.Toolkit.Pagination;

namespace TariffConstructor.Domain.BillingSettingAggregate
{
    public interface IBillingSettingRepository : IRepository<BillingSetting>
    {
        Task<BillingSetting> GetBillingSetting(int id);
        Task<IReadOnlyList<BillingSetting>> GetBillingSettings();
        Task<PaginationResult<BillingSetting>> Pagination(BillingSettingPaginationPattern searchPattern);
    }
}
