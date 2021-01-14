﻿using System.Collections.Generic;
using System.Linq;
using TariffConstructor.AdminApi.Dto.BillingSetting;
using TariffConstructor.AdminApi.Mappers.SettingMap;
using TariffConstructor.Domain.BillingSettingAggregate;

namespace TariffConstructor.AdminApi.Mappers.BillingSettingMap
{
    public static class BillingSettingMap
    {
        public static BillingSettingDto Map(this BillingSetting billingSetting)
        {
            if (billingSetting == null)
            {
                return null;
            }
            else
            {
                return new BillingSettingDto
                {
                    Id = billingSetting.Id,
                    SettingId = billingSetting.SettingId,
                    Setting = billingSetting.Setting.Map()
                };
            }
        }

        public static IReadOnlyList<BillingSettingDto> Map(this IEnumerable<BillingSetting> billingSettings)
        {
            return billingSettings == null ? new List<BillingSettingDto>() : billingSettings.Select(Map).ToList();
        }
    }
}
