using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace TariffConstructor.AdminApi.Modules.CurrencyModule
{
    [DataContract]
    public class CurrencyReadOnlyDto
    {
        [DataMember(Name = "id")]
        public int Id { get; private set; }

        [Required]
        [DataMember(Name = "code")]
        public int Code { get; private set; }
        
        [Required]
        [DataMember(Name = "name")]
        public string Name { get; private set; }
    }
}
