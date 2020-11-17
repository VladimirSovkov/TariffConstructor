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
                    PublicId = tariff.PublicId,
                    Name = tariff.Name,
                    PaymentType = (int)tariff.PaymentType
                    //ContractKindBindings = tariff.ContractKindBindings.ToList()
                };
            }
        }

        public static List<TariffDto> Map(this IEnumerable<Tariff> tariff)
        {
            return tariff == null ? new List<TariffDto>() : tariff.ToList().ConvertAll(Map);
        }
    }
}
