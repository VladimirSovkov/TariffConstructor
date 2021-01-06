using System.Runtime.Serialization;
using TariffConstructor.Domain.SettingAggregate;

namespace TariffConstructor.AdminApi.Dto.BillingSetting
{
    [DataContract]
    public class BillingSettingDto
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "settingId")]
        public int SettingId { get; set; }
    }
}
