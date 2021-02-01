using System.Runtime.Serialization;
using TariffConstructor.AdminApi.Dto.Setting;

namespace TariffConstructor.AdminApi.Dto.BillingSetting
{
    [DataContract]
    public class BillingSettingPresetDto
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "settingsPresetId")]
        public int SettingsPresetId { get; set; }

        [DataMember(Name = "billingSettingId")]
        public int BillingSettingId { get; set; }
        
        [DataMember(Name = "billingSetting")]
        public BillingSettingDto BillingSetting { get; set; }

        [DataMember(Name = "value")]
        public SettingPresetValueDto Value { get; set; }

        [DataMember(Name = "isRequired")]
        public bool IsRequired { get; set; }

        [DataMember(Name = "isReadOnly")]
        public bool IsReadOnly { get; set; }

        [DataMember(Name = "isHidden")]
        public bool IsHidden { get; set; }
    }
}
