using System.Runtime.Serialization;

namespace TariffConstructor.AdminApi.Modules.TermsOfUseModule
{
    [DataContract]
    public class TermsOfUseDto
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "publicId")]
        public string PublicId { get; set; }
        
        [DataMember(Name = "documentName")]
        public string DocumentName { get; set; }
    }
}
