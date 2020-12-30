using System.Runtime.Serialization;

namespace TariffConstructor.AdminApi.Dto.ApplicationSetting
{
    [DataContract]
    public class ApplicationSettingDto
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        
        [DataMember(Name = "applicationId")]
        public int ApplicationId { get; set; }
        
        [DataMember(Name = "settingId")]
        public int SettingId { get; set; }
        
        [DataMember(Name = "defaultValue")]
        public string DefaultValue { get; set; }
    }
}
