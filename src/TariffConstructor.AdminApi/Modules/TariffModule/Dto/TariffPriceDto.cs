using System.Runtime.Serialization;
using TariffConstructor.AdminApi.Dto.ValueObject;

namespace TariffConstructor.AdminApi.Modules.TariffModule.Dto
{
    [DataContract]
    public class TariffPriceDto
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "price")]
        public PriceDto Price { get; set; }

        [DataMember(Name = "period")]
        public ProlongationPeriodDto Period { get; set; }

        [DataMember(Name = "tariffId")]
        public int TariffId { get; set; }
    }
}
