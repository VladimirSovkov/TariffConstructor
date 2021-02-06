using System.Runtime.Serialization;
using TariffConstructor.AdminApi.Modules.ProductOptionModule;

namespace TariffConstructor.AdminApi.Modules.TariffModule.Dto
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

        [DataMember(Name = "productOption")]
        public ProductOptionDto ProductOption { get; set; }
    }
}
