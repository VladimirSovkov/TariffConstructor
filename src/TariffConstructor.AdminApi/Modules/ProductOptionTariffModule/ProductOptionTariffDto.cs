using System.Collections.Generic;
using System.Runtime.Serialization;
using TariffConstructor.AdminApi.Dto.ProductOptionTariff;
using TariffConstructor.AdminApi.Modules.ProductOptionModule;

namespace TariffConstructor.AdminApi.Modules.ProductOptionTariffModule
{
    [DataContract]
    public class ProductOptionTariffDto
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "productOptionId")]
        public int ProductOptionId { get; set; }
        
        [DataMember(Name = "productOption")]
        public ProductOptionDto ProductOption { get; set; }
        
        [DataMember(Name = "name")]
        public string Name { get; set; }
        
        [DataMember(Name = "prices")]
        public List<ProductOptionTariffPriceDto> Prices { get; set; } 
    }
}
