using System.Runtime.Serialization;
using TariffConstructor.AdminApi.Dto.SettingDto;

namespace TariffConstructor.AdminApi.Dto.ApplicationSetting
{
    [DataContract]
    public class ApplicationSettingPresetDto
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        
        [DataMember(Name = "settingsPresetId")]
        public int SettingsPresetId { get; set; }
        
        [DataMember(Name = "applicationSettingId")]
        public int ApplicationSettingId { get; set; }
        
        [DataMember(Name = "value")]
        public SettingPresetValueDto Value { get; set; }

        [DataMember(Name = "isRequired")]
        public bool IsRequired { get; set; }
        
        [DataMember(Name = "isReadOnly")]
        public bool IsReadOnly { get; set; }
     
        [DataMember(Name = "isHidden")]
        public bool IsHidden { get; set; }
    }
}
