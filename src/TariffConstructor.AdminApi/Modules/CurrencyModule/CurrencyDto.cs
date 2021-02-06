using System.Runtime.Serialization;

namespace TariffConstructor.AdminApi.Modules.CurrencyModule
{
    [DataContract]
    public class CurrencyDto
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "code")]
        public int Code { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}
