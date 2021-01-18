using System.Collections.Generic;
using System.Runtime.Serialization;
using TariffConstructor.Domain.TariffModel;

namespace TariffConstructor.AdminApi.Dto
{
    [DataContract]
    public class SimplifiedTariffDto
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "tenantId")]
        public int TenantId { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "paymentType")]
        public int PaymentType { get; set; }

        [DataMember(Name = "contractKindBindings")]
        public List<TariffToContractKindBinding> ContractKindBindings { get; set; }
    }
}
