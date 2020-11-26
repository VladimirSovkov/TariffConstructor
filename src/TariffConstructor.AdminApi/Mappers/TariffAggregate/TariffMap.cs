using System.Collections.Generic;
using System.Linq;
using TariffConstructor.AdminApi.Dto;
using TariffConstructor.Domain.TariffAggregate;

namespace TariffConstructor.AdminApi.Mappers.TariffAggregate
{
    public static class TariffMap
    {
        public static TariffDto Map(this Tariff tariff)
        {
            if (tariff == null)
            {
                return null;
            }
            else
            {
                return new TariffDto
                {
                    Id = tariff.Id,
                    TenantId = tariff.TenantId,
                    Name = tariff.Name,
                    PaymentType = (int)tariff.PaymentType,
                    ContractKindBindings = tariff.ContractKindBindings.ToList()
                };
            }
        }

        public static IReadOnlyList<TariffDto> Map(this IEnumerable<Tariff> tariffs)
        {
            return tariffs == null ? new List<TariffDto>() : tariffs.Select(Map).ToList();
        }
    }
}
