using System.Collections.Generic;
using System.Linq;
using TariffConstructor.AdminApi.Dto.Setting;
using TariffConstructor.AdminApi.Mappers.ApplicationSettingMap;
using TariffConstructor.AdminApi.Mappers.BillingSettingMap;
using TariffConstructor.Domain.SettingModel;

namespace TariffConstructor.AdminApi.Mappers.SettingMap
{
    public static class SettingsPresetMap
    {
        public static SettingsPresetDto Map(this SettingsPreset settingsPreset)
        {
            if (settingsPreset == null)
            {
                return null;
            }
            else
            {
                return new SettingsPresetDto
                {
                    Id = settingsPreset.Id,
                    Name = settingsPreset.Name,
                    ApplicationSettingPresets = settingsPreset.ApplicationSettingPresets.Map(),
                    BillingSettingPresets = settingsPreset.BillingSettingPresets.Map()
                };
            }
        }

        public static IReadOnlyList<SettingsPresetDto> Map(this IEnumerable<SettingsPreset> settingsPresets)
        {
            return settingsPresets == null ? new List<SettingsPresetDto>() : settingsPresets.Select(Map).ToList();
        }
    }
}
