using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TariffConstructor.AdminApi.Modules.TariffModule.Dto
{
    [DataContract]
    public class TariffDto
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "isArchived")]
        public bool IsArchived { get; set; }

        [DataMember(Name = "testPeriod")]
        public TariffTestPeriodDto TestPeriod { get; set; }

        [DataMember(Name = "accountingName")]
        public string AccountingName { get; set; }

        [DataMember(Name = "paymentType")]
        public int PaymentType { get; set; }

        [DataMember(Name = "awaitingPaymentStrategy")]
        public string AwaitingPaymentStrategy { get; set; }

        [DataMember(Name = "accountingTariffId")]
        public string AccountingTariffId { get; set; }

        [DataMember(Name = "settingsPresetId")]
        public int SettingsPresetId { get; set; }

        [DataMember(Name = "termsOfUseId")]
        public int TermsOfUseId { get; set; }

        [DataMember(Name = "isAcceptanceRequired")]
        public bool IsAcceptanceRequired { get; set; }

        [DataMember(Name = "isGradualFinishAvailable")]
        public bool IsGradualFinishAvailable { get; set; }

        [DataMember(Name= "prices")]
        public List<TariffPriceDto> Prices { get; set; }    

        [DataMember(Name = "advancePrices")]
        public List<TariffAdvancePriceDto> AdvancePrices { get; set;}
    
        [DataMember(Name = "includedProducts")]
        public List<IncludedProductInTariffDto> IncludedProducts { get; set; }

        [DataMember(Name = "includedProductOptions")]
        public List<IncludedProductOptionInTariffDto> IncludedProductOptions { get; set; }

        [DataMember(Name = "contractKindBindings")]
        public List<TariffToContractKindBindingDto> ContractKindBindings { get; set; }
    }
}
