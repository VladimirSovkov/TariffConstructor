﻿using System.Collections.Generic;
using System.Threading.Tasks;
using TariffConstructor.Toolkit.Abstractions;
using TariffConstructor.Toolkit.Search;

namespace TariffConstructor.Domain.SettingModel
{
    public interface ISettingsPresetRepository : IRepository<SettingsPreset>
    {
        Task<List<SettingsPreset>> GetSettingsPresets();
        Task<SettingsPreset> GetSettingsPreset(int id);
        Task<SearchResult<SettingsPreset>> Search(SettingsPresetSearchPattern searchPattern);
    }
}
