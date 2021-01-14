﻿using System.Runtime.Serialization;
using TariffConstructor.Domain.SettingAggregate;
using TariffConstructor.AdminApi.Dto.Setting;

namespace TariffConstructor.AdminApi.Dto.BillingSetting
{
    [DataContract]
    public class BillingSettingDto
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "settingId")]
        public int SettingId { get; set; }

        [DataMember(Name = "setting")]
        public SettingDto Setting { get; set; }
    }
}
