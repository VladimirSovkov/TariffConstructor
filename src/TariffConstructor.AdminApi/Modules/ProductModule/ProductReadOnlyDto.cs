using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace TariffConstructor.AdminApi.Modules.ProductModule
{
    [DataContract]
    public class ProductReadOnlyDto
    {
        [DataMember(Name = "id")]
        public int Id { get; private set; }

        [Required]
        [DataMember(Name = "name")]
        public string Name { get; private set; }

        [Required]
        [DataMember(Name = "publicId")]
        public string PublicId { get; private set; }

        [Required]
        [DataMember(Name = "nomenclatureId")]
        public string NomenclatureId { get; private set; }

        [Required]
        [DataMember(Name = "shortName")]
        public string ShortName { get; private set; }
    }
}
