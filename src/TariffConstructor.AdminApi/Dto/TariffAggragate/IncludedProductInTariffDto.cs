using System.Runtime.Serialization;

namespace TariffConstructor.AdminApi.Dto.TariffAggragate
{
    [DataContract]
    public class IncludedProductInTariffDto
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "tariffId")]
        public int TariffId { get; set; }

        [DataMember(Name = "productId")]
        public int ProductId { get; set; }

        [DataMember(Name = "relativeWeight")]
        public int RelativeWeight { get; set; }
    }
}
