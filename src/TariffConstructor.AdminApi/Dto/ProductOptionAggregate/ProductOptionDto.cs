using System.Runtime.Serialization;

namespace TariffConstructor.AdminApi.Dto
{
    [DataContract]
    public class ProductOptionDto
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "nomenclatureId")]
        public string NomenclatureId { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "productId")]
        public int ProductId { get; set; }

        [DataMember(Name = "isMultiple")]
        public bool IsMultiple { get; set; }

        [DataMember(Name = "accountingName")]
        public string AccountingName { get; set; }
    }
}
