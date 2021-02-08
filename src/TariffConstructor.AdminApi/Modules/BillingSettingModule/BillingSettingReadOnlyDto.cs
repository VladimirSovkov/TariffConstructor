using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace TariffConstructor.AdminApi.Modules.BillingSettingModule
{
    [DataContract]
    public class BillingSettingReadOnlyDto
    {
        [DataMember(Name = "id")]
        public int Id { get; private set; }

        [Required]
        [DataMember(Name = "settingId")]
        public int SettingId { get; private set; }
    }
}
