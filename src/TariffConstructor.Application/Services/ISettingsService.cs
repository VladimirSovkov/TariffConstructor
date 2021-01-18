﻿using System.Threading.Tasks;
using TariffConstructor.Domain.SettingModel;
using TariffConstructor.Domain.Settings;

namespace TariffConstructor.Application.Services
{
    public interface ISettingsService
    {
        Task<SettingsSet> CreateSettingsSet(int settingsPresetId, SettingsContainer settings = null);
    }
}
