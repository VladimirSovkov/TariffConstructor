using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace TariffConstructor.AdminApi.Modules.SettingModule
{
    [DataContract]
    public class SettingreadOnlyDto
    {
        [DataMember(Name = "id")]
        public int Id { get; private set; }

        [Required]
        [DataMember(Name = "type")]
        public int Type { get; private set; }

        [Required]
        [DataMember(Name = "code")]
        public string Code { get; private set; }

        [Required]
        [DataMember(Name = "name")]
        public string Name { get; private set; }

        [DataMember(Name = "description")]
        public string Description { get; private set; }

        [DataMember(Name = "isComputing")]
        public bool IsComputing { get; private set; }
    }
}
