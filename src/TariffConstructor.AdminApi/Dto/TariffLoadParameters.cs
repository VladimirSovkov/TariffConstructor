using System.Runtime.Serialization;
using TariffConstructor.Domain.TariffAggregate;
using TariffConstructor.Domain.ValueObjects;

namespace TariffConstructor.AdminApi.Dto
{
    [DataContract]
    public class TariffLoadParameters
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "IsArchived")]
        public bool IsArchived { get; set; }

        [DataMember(Name = "Value")]
        public int Value { get; set; }
        
        [DataMember(Name = "Unit")]
        public string Unit { get; set; }

        [DataMember(Name = "AccountingName")]
        public string AccountingName { get; set; }

        [DataMember(Name = "PaymentType")]
        public string PaymentType { get; set; }

        [DataMember(Name = "AwaitingPaymentStrategy")]
        public string AwaitingPaymentStrategy { get;  set; }

        [DataMember(Name = "AccountingTariffId")]
        public string AccountingTariffId { get;  set; }

        [DataMember(Name = "SettingsPresetId")]
        public int SettingsPresetId { get;  set; }

        [DataMember(Name = "TermsOfUseId")]
        public int TermsOfUseId { get;  set; }

        [DataMember(Name = "IsAcceptanceRequired")]
        public bool IsAcceptanceRequired { get; set; }

        [DataMember(Name = "IsGradualFinishAvailable")]
        public bool IsGradualFinishAvailable { get; set; }
    }
}
