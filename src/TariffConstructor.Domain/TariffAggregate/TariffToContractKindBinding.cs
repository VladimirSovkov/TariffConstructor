using TariffConstructor.Domain.Abstractions;

namespace TariffConstructor.Domain.TariffAggregate
{
    public class TariffToContractKindBinding : Entity
    {
        public TariffToContractKindBinding( int contractKindId )
        {
            ContractKindId = contractKindId;
        }

        public int TariffId { get; private set; }
        public int ContractKindId { get; private set; }

        protected TariffToContractKindBinding()
        {
        }
    }
}
