using System.Runtime.Serialization;
using TariffConstructor.AdminApi.Modules.ProductModule;

namespace TariffConstructor.AdminApi.Modules.ProductOptionModule
{
    [DataContract]
    public class ProductOptionDto
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "publicId")]
        public string PublicId { get; set; }

        [DataMember(Name = "nomenclatureId")]
        public string NomenclatureId { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "productId")]
        public int ProductId { get; set; }

        [DataMember(Name = "productName")]
        public string  ProductName { get; set; }

        [DataMember(Name = "isMultiple")]
        public bool IsMultiple { get; set; }

        [DataMember(Name = "accountingName")]
        public string AccountingName { get; set; }
    }
}
