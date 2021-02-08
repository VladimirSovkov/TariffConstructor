using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using TariffConstructor.AdminApi.Modules.ApplicationModule;
using TariffConstructor.AdminApi.Modules.SettingModule;

namespace TariffConstructor.AdminApi.Modules.ApplicationSettingModule
{
    [DataContract]
    public class ApplicationsetingReadOnlyDto
    {
        [DataMember(Name = "id")]
        public int Id { get; private set; }

        [Required]
        [DataMember(Name = "applicationId")]
        public int ApplicationId { get; private set; }

        [Required]
        [DataMember(Name = "settingId")]
        public int SettingId { get; private set; }

        [DataMember(Name = "defaultValue")]
        public string DefaultValue { get; private set; }
    }
}
}
