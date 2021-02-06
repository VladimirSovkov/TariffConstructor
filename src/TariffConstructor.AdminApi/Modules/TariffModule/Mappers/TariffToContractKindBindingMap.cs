using System.Collections.Generic;
using System.Linq;
using TariffConstructor.AdminApi.Modules.ContractKindModule;
using TariffConstructor.AdminApi.Modules.TariffModule.Dto;
using TariffConstructor.Domain.TariffModel;

namespace TariffConstructor.AdminApi.Mappers.TariffMap
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
                    ContractKindId = tariffToContractKindBinding.ContractKindId,
                    ContractKind = tariffToContractKindBinding.ContractKind.Map()
                };
            }
        }

        public static IReadOnlyList<TariffToContractKindBindingDto> Map (this IEnumerable<TariffToContractKindBinding> tariffToContractKindBindings)
        {
            return tariffToContractKindBindings == null ? new List<TariffToContractKindBindingDto>() : tariffToContractKindBindings.Select(Map).ToList();
        }
    }
}
