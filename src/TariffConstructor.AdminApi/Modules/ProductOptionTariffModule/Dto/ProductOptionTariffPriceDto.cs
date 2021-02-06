using System.Runtime.Serialization;
using TariffConstructor.AdminApi.Dto.ValueObject;

namespace TariffConstructor.AdminApi.Dto.ProductOptionTariff.Dto
{
    [DataContract]
    public class ProductOptionTariffPriceDto
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "price")]
        public PriceDto Price { get; set; }

        [DataMember(Name = "period")]
        public ProlongationPeriodDto Period { get; set; }
    }
}
