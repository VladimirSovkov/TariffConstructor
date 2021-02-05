using System.Collections.Generic;
using System.Threading.Tasks;
using TariffConstructor.Toolkit.Abstractions;
using TariffConstructor.Toolkit.Search;

namespace TariffConstructor.Domain.SettingModel
{
    public interface ISettingRepository : IRepository<Setting>
    {
        Task<Setting> GetSetting(int id);
        Task<IReadOnlyList<Setting>> GetSettings();
        Task<SearchResult<Setting>> Search(SettingSearchPattern searchPattern);
    }
}
