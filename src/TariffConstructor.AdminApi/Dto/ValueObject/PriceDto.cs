using System.Runtime.Serialization;

namespace TariffConstructor.AdminApi.Dto.ValueObject
{
    [DataContract]
    public class PriceDto
    {
        [DataMember(Name = "value")]
        public decimal Value { get; set; }

        [DataMember(Name = "currency")]
        public string Currency { get; set; }
    }
}
