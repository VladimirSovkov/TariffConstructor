﻿using System.Runtime.Serialization;

namespace TariffConstructor.AdminApi.Dto.TariffAggragate
{
    [DataContract]
    public class TariffToContractKindBindingDto
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "tariffId")]
        public int TariffId { get; set; }

        [DataMember(Name = "contractKindId")]
        public int ContractKindId { get; set; }
    }
}
