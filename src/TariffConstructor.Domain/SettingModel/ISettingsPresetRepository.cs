using System.Threading.Tasks;
using TariffConstructor.Domain.SearchPattern;
using TariffConstructor.Toolkit.Abstractions;
using TariffConstructor.Toolkit.Search;

namespace TariffConstructor.Domain.SettingModel
{
    public interface ISettingsPresetRepository : IRepository<SettingsPreset>
    {
        Task<SettingsPreset> GetSettingsPreset(int id);
        Task<SearchResult<SettingsPreset>> Search(SettingsPresetSearchPattern searchPattern);
    }
}
