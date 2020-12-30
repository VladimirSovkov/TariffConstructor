using System.Collections.Generic;
using System.Threading.Tasks;
using TariffConstructor.Domain.SearchPattern;
using TariffConstructor.Toolkit.Abstractions;
using TariffConstructor.Toolkit.Search;

namespace TariffConstructor.Domain.SettingAggregate
{
    public interface ISettingRepository : IRepository<Setting>
    {
        Task<Setting> GetSetting(int id);
        Task<IReadOnlyList<Setting>> GetSettings();
        Task<SearchResult<Setting>> Search(SettingSearchPattern searchPattern);
    }
}
