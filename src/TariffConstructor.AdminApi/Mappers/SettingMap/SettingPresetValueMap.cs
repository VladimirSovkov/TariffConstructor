using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TariffConstructor.AdminApi.Dto.SettingDto;
using TariffConstructor.Domain.SettingAggregate;

namespace TariffConstructor.AdminApi.Mappers.SettingMap
{
    public static class SettingPresetValueMap
    {
        public static SettingPresetValueDto Map(this SettingPresetValue settingPresetValue)
        {
            if (settingPresetValue == null)
            {
                return null;
            }
            else
            {
                return new SettingPresetValueDto
                {
                    DefaultValue = settingPresetValue.DefaultValue,
                    MaxValue = settingPresetValue.MaxValue,
                    MinValue = settingPresetValue.MinValue
                };
            }
        }

        public static IReadOnlyList<SettingPresetValueDto> Map(this IEnumerable<SettingPresetValue> settingPresetValues)
        {
            return settingPresetValues == null ? new List<SettingPresetValueDto>() : settingPresetValues.Select(Map).ToList();
        }
    }
}
