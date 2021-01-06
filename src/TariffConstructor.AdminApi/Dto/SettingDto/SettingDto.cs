using System.Runtime.Serialization;

namespace TariffConstructor.AdminApi.Dto.SettingDto
{
    [DataContract]
    public class SettingDto
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "type")]
        public int Type { get; set; }

        [DataMember(Name = "code")]
        public string Code { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
        
        [DataMember(Name = "description")]
        public string Description { get; set; }
        
        [DataMember(Name = "isComputing")]
        public bool IsComputing { get; set; }

    }
}
