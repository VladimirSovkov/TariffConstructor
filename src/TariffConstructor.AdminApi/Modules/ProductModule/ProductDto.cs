using System.Runtime.Serialization;

namespace TariffConstructor.AdminApi.Modules.ProductModule
{
    [DataContract]
    public class ProductDto
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "publicId")]
        public string PublicId { get; set; }

        [DataMember(Name = "nomenclatureId")]
        public string NomenclatureId { get; set; }

        [DataMember(Name = "shortName")]
        public string ShortName { get; set; }

        [DataMember(Name = "id")]
        public int Id { get; set; }
    }
}
