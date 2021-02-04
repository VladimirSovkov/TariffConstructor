using System.Runtime.Serialization;

namespace TariffConstructor.AdminApi.Dto.Application
{
    [DataContract]
    public class ApplicationDto
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "publicId", )]
        public string PublicId { get; set; }
  
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}
