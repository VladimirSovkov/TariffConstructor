using System.Collections.Generic;
using System.Runtime.Serialization;
using TariffConstructor.AdminApi.Dto.ApplicationSetting;
using TariffConstructor.AdminApi.Dto.BillingSettingDto;

namespace TariffConstructor.AdminApi.Dto.SettingDto
{
    [DataContract]
    public class SettingsPresetDto
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
        
        [DataMember(Name = "billingSettingPresets")]
        public List<BillingSettingPresetDto> BillingSettingPresets { get; set; }
        
        [DataMember(Name = "applicationSettingPresets")]
        public List<ApplicationSettingPresetDto> ApplicationSettingPresets { get; set; }
    }
}
