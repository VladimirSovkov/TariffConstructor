using System.Collections.Generic;
using System.Linq;
using TariffConstructor.AdminApi.Dto.TariffAggragate;
using TariffConstructor.Domain.TariffAggregate;

namespace TariffConstructor.AdminApi.Mappers.TariffAggregate
{
    public static class TariffToContractKindBindingMap
    {
        public static TariffToContractKindBindingDto Map (this TariffToContractKindBinding tariffToContractKindBinding)
        {
            if ( tariffToContractKindBinding == null)
            {
                return null;
            }
            else
            {
                return new TariffToContractKindBindingDto
                {
                    Id = tariffToContractKindBinding.Id,
                    TariffId = tariffToContractKindBinding.TariffId,
                    ContractKindId = tariffToContractKindBinding.ContractKindId
                };
            }
        }

        public static IReadOnlyList<TariffToContractKindBindingDto> Map (this IEnumerable<TariffToContractKindBinding> tariffToContractKindBindings)
        {
            return tariffToContractKindBindings == null ? new List<TariffToContractKindBindingDto>() : tariffToContractKindBindings.Select(Map).ToList();
        }
    }
}
