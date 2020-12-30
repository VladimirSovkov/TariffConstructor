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

        [DataMember(Name = "isArchived")]
        public bool IsArchived { get; set; }

        [DataMember(Name = "value")]
        public int Value { get; set; }
        
        [DataMember(Name = "unit")]
        public string Unit { get; set; }

        [DataMember(Name = "accountingName")]
        public string AccountingName { get; set; }

        [DataMember(Name = "paymentType")]
        public string PaymentType { get; set; }

        [DataMember(Name = "awaitingPaymentStrategy")]
        public string AwaitingPaymentStrategy { get;  set; }

        [DataMember(Name = "accountingTariffId")]
        public string AccountingTariffId { get;  set; }

        [DataMember(Name = "settingsPresetId")]
        public int SettingsPresetId { get;  set; }

        [DataMember(Name = "termsOfUseId")]
        public int TermsOfUseId { get;  set; }

        [DataMember(Name = "isAcceptanceRequired")]
        public bool IsAcceptanceRequired { get; set; }

        [DataMember(Name = "isGradualFinishAvailable")]
        public bool IsGradualFinishAvailable { get; set; }
    }
}
