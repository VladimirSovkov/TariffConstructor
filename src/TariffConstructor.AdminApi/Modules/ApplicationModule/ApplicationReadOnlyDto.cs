using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

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
