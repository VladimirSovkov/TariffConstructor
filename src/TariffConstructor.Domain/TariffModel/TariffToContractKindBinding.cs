using TariffConstructor.Domain.ContractKindModel;
using TariffConstructor.Toolkit.Abstractions;

namespace TariffConstructor.Domain.TariffModel
{
    public class TariffToContractKindBinding : Entity
    {
        public TariffToContractKindBinding( int contractKindId )
        {
            ContractKindId = contractKindId;
        }

        public int TariffId { get; private set; }
        public int ContractKindId { get; private set; }
        public virtual ContractKind ContractKind { get; private set; }

        public void SetContractKindId(int contractKindId)
        {
            if (ContractKindId == contractKindId)
            {
                ContractKindId = contractKindId;
            }
        }

        protected TariffToContractKindBinding()
        {
        }
    }
}
