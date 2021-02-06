using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TariffConstructor.AdminApi.Modules.SettingsPresetModule
{
    [DataContract]
    public class SettingsPresetDto
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
        
        [DataMember(Name = "billingsSettingPresets")]
        public List<BillingSettingPresetDto> BillingSettingPresets { get; set; }
        
        [DataMember(Name = "applicationSettingsPresets")]
        public List<ApplicationSettingPresetDto> ApplicationSettingPresets { get; set; }
    }
}
