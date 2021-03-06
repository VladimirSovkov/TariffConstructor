﻿using System.Collections.Generic;
using System.Linq;
using TariffConstructor.AdminApi.Modules.BillingSettingModule;
using TariffConstructor.Domain.BillingSettingModel;

namespace TariffConstructor.AdminApi.Modules.SettingsPresetModule
{
    public static class BillingSettingPresetMap
    {
        public static BillingSettingPresetDto Map(this BillingSettingPreset billingSettingPreset)
        {
            if (billingSettingPreset == null)
            {
                return null;
            }
            else
            {
                return new BillingSettingPresetDto
                {
                    Id = billingSettingPreset.Id,
                    BillingSettingId = billingSettingPreset.BillingSettingId,
                    BillingSetting = billingSettingPreset.BillingSetting.Map(),
                    SettingsPresetId = billingSettingPreset.SettingsPresetId,
                    IsHidden = billingSettingPreset.IsHidden,
                    IsReadOnly = billingSettingPreset.IsReadOnly,
                    IsRequired = billingSettingPreset.IsRequired,
                    Value = billingSettingPreset.Value.Map()
                };
            }
        }

        public static List<BillingSettingPresetDto> Map(this IEnumerable<BillingSettingPreset> billingSettingPresets)
        {
            return billingSettingPresets == null ? new List<BillingSettingPresetDto>() : billingSettingPresets.Select(Map).ToList();
        }
    }
}
