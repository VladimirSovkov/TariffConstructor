using System.Runtime.Serialization;

namespace TariffConstructor.AdminApi.Dto
{
    [DataContract]
    public class ProductDto
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "nomenclatureId")]
        public string NomenclatureId { get; set; }

        [DataMember(Name = "shortName")]
        public string ShortName { get; set; }
    }
}
