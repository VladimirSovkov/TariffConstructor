using System.Runtime.Serialization;
using TariffConstructor.AdminApi.Modules.ApplicationModule;
using TariffConstructor.AdminApi.Modules.SettingModule;

namespace TariffConstructor.AdminApi.Modules.ApplicationSettingModule
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
