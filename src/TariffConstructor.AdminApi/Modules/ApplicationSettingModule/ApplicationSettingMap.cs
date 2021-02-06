using System.Collections.Generic;
using System.Linq;
using TariffConstructor.AdminApi.Modules.ApplicationModule;
using TariffConstructor.AdminApi.Modules.SettingModule;
using TariffConstructor.Domain.ApplicationSettingModel;

namespace TariffConstructor.AdminApi.Modules.ApplicationSettingModule
{
    public static class ApplicationSettingMap
    {
        public static ApplicationSettingDto Map(this ApplicationSetting applicationSetting)
        {
            if (applicationSetting == null)
            {
                return null;
            }
            else
            {
                return new ApplicationSettingDto
                {
                    Id = applicationSetting.Id,
                    ApplicationId = applicationSetting.ApplicationId,
                    SettingId = applicationSetting.SettingId,
                    DefaultValue = applicationSetting.DefaultValue,
                    Application = applicationSetting.Application.Map(),
                    Setting = applicationSetting.Setting.Map()
                };
            }
        }

        public static IReadOnlyList<ApplicationSettingDto> Map (this IEnumerable<ApplicationSetting> applicationSettings)
        {
            return applicationSettings == null ? new List<ApplicationSettingDto>() : applicationSettings.Select(Map).ToList();
        }
    }
}
