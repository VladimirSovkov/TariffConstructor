using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace TariffConstructor.AdminApi.Modules.ContractKindModule
{
    [DataContract]
    public class ContractKindReadOnlyDto
    {
        [DataMember(Name = "id")]
        public int Id { get; private set; }

        [Required]
        [DataMember(Name = "publicId")]
        public string PublicId { get; private set; }

        [Required]
        [DataMember(Name = "name")]
        public string Name { get; private set; }
    }
}
