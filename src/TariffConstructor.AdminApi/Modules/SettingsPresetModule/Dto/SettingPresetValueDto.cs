using System.Runtime.Serialization;

namespace TariffConstructor.AdminApi.Modules.SettingsPresetModule
{
    [DataContract]
    public class SettingPresetValueDto
    {
        [DataMember(Name = "defaultValue")]
        public string DefaultValue { get; set; }

        [DataMember(Name = "minValue")]
        public string MinValue { get; set; }
        
        [DataMember(Name = "maxValue")]
        public string MaxValue { get; set; }
    }
}
