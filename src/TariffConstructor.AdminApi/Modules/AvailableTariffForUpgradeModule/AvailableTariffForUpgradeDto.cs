using System.Runtime.Serialization;

namespace TariffConstructor.AdminApi.Modules.AvailableTariffForUpgradeModule
{
    [DataContract]
    public class AvailableTariffForUpgradeDto
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "fromTariffId")]
        public int FromTariffId { get; set; }

        [DataMember(Name = "toTariffId")]
        public int ToTariffId { get; set; }
    }
}
