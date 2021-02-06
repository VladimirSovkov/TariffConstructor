using System.Collections.Generic;
using System.Linq;
using TariffConstructor.AdminApi.Dto.ApplicationSetting;
using TariffConstructor.AdminApi.Mappers.SettingMap;
using TariffConstructor.AdminApi.Modules.ApplicationSettingModule;
using TariffConstructor.Domain.ApplicationSettingModel;

namespace TariffConstructor.AdminApi.Mappers.ApplicationSettingMap
{
    public static class ApplicationSettingPresetMap
    {
        public static ApplicationSettingPresetDto Map (this ApplicationSettingPreset applicationSettingPreset)
        {
            if (applicationSettingPreset == null)
            {
                return null;
            }
            else
            {
                return new ApplicationSettingPresetDto
                {
                    Id = applicationSettingPreset.Id,
                    ApplicationSettingId = applicationSettingPreset.ApplicationSettingId,
                    ApplicationSetting = applicationSettingPreset.ApplicationSetting.Map(),
                    IsHidden = applicationSettingPreset.IsHidden,
                    IsReadOnly = applicationSettingPreset.IsReadOnly,
                    IsRequired = applicationSettingPreset.IsRequired,
                    SettingsPresetId = applicationSettingPreset.SettingsPresetId,
                    Value = applicationSettingPreset.Value.Map()
                };
            }
        }

        public static List<ApplicationSettingPresetDto> Map(this IEnumerable<ApplicationSettingPreset> applicationSettingPresets)
        {
            return applicationSettingPresets == null ? new List<ApplicationSettingPresetDto>() : applicationSettingPresets.Select(Map).ToList();
        }
    }
}
