using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace TariffConstructor.AdminApi.Modules.ProductOptionModule
{
    [DataContract]
    public class ProductOptionReadOnlyDto
    {
        [DataMember(Name = "id")]
        public int Id { get; private set; }

        [Required]
        [DataMember(Name = "publicId")]
        public string PublicId { get; private set; }

        [Required]
        [DataMember(Name = "nomenclatureId")]
        public string NomenclatureId { get; private set; }

        [Required]
        [DataMember(Name = "name")]
        public string Name { get; private set; }

        [Required]
        [DataMember(Name = "productId")]
        public int ProductId { get; private set; }

        [DataMember(Name = "isMultiple")]
        public bool IsMultiple { get; private set; }

        [DataMember(Name = "accountingName")]
        public string AccountingName { get; private set; }
    }
}
