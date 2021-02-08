using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace TariffConstructor.AdminApi.Modules.AvailableTariffForUpgradeModule
{
    [DataContract]
    public class AvailableTariffForUpgradeReadOnlyDto
    {
        [DataMember(Name = "id")]
        public int Id { get; private set; }

        [Required]
        [DataMember(Name = "fromTariffId")]
        public int FromTariffId { get; private set; }
        
        [Required]
        [DataMember(Name = "toTariffId")]
        public int ToTariffId { get; private set; }
    }
}
