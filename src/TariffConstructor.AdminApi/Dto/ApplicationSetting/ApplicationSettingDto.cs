using System.Runtime.Serialization;
using TariffConstructor.AdminApi.Dto.Application;
using TariffConstructor.AdminApi.Dto.Setting;

namespace TariffConstructor.AdminApi.Dto.ApplicationSetting
{
    [DataContract]
    public class ApplicationSettingDto
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        
        [DataMember(Name = "applicationId")]
        public int ApplicationId { get; set; }

        [DataMember(Name = "application")]
        public ApplicationDto Application { get; set; }

        [DataMember(Name = "settingId")]
        public int SettingId { get; set; }

        [DataMember(Name = "setting")]
        public SettingDto Setting { get; set; } 
        
        [DataMember(Name = "defaultValue")]
        public string DefaultValue { get; set; }
    }
}
