using System.Runtime.Serialization;

namespace TariffConstructor.AdminApi.Dto.TariffAggragate
{
    [DataContract]
    public class IncludedProductOptionInTariffDto
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "quantity")]
        public int Quantity { get; set; }

        [DataMember(Name = "tariffId")]
        public int TariffId { get; set; }

        [DataMember(Name = "productOptionId")]
        public int ProductOptionId { get; set; }
    }
}
