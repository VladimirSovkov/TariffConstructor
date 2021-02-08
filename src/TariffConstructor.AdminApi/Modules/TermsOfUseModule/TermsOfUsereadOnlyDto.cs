using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace TariffConstructor.AdminApi.Modules.TermsOfUseModule
{
    [DataContract]
    public class TermsOfUsereadOnlyDto
    {
        [DataMember(Name = "id")]
        public int Id { get; private set; }

        [Required]
        [DataMember(Name = "publicId")]
        public string PublicId { get; private set; }
        
        [Required]
        [DataMember(Name = "documentName")]
        public string DocumentName { get; private set; }
    }
}
