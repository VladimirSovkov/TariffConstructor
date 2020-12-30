using System.Collections.Generic;
using System.Linq;
using TariffConstructor.AdminApi.Dto.ApplicationSetting;
using TariffConstructor.Domain.ApplicationSettingAggregate;

namespace TariffConstructor.AdminApi.Mappers.ApplicationSettingMap
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
                    DefaultValue = applicationSetting.DefaultValue
                };
            }
        }

        public static IReadOnlyList<ApplicationSettingDto> Map (this IEnumerable<ApplicationSetting> applicationSettings)
        {
            return applicationSettings == null ? new List<ApplicationSettingDto>() : applicationSettings.Select(Map).ToList();
        }
    }
}
