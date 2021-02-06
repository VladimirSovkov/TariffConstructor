using System.Runtime.Serialization;
using TariffConstructor.AdminApi.Modules.ProductModule;

namespace TariffConstructor.AdminApi.Modules.TariffModule.Dto
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
        [DataMember(Name = "product")]
        public ProductDto Product { get; set; }

        [DataMember(Name = "relativeWeight")]
        public int RelativeWeight { get; set; }
    }
}
