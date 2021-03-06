﻿using System.Collections.Generic;
using System.Linq;
using TariffConstructor.Domain.SettingModel;

namespace TariffConstructor.AdminApi.Modules.SettingModule
{
    public static class SettingMap
    {
        public static SettingDto Map (this Setting setting)
        {
            if (setting == null)
            {
                return null;
            }
            else
            {
                return new SettingDto
                {
                    Id = setting.Id,
                    Type = (int)setting.Type,
                    Code = setting.Code,
                    Name = setting.Name,
                    Description = setting.Description,
                    IsComputing = setting.IsComputing,
                };
            }
        }

        public static IReadOnlyList<SettingDto> Map(this IEnumerable<Setting> settings)
        {
            return settings == null ? new List<SettingDto>() : settings.Select(Map).ToList();        }
    }
}
