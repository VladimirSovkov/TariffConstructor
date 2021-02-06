using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace TariffConstructor.AdminApi.Modules.ApplicationModule
{
    [DataContract]
    public class ApplicationReadOnlyDto
    {
        [DataMember(Name = "id")]
        public int Id { get; private set; }

        [Required]
        [DataMember(Name = "publicId")]
        public string PublicId { get; private set; }

        [Required]
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}
