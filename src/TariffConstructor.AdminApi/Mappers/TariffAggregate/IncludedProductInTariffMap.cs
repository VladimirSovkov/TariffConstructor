using System.Collections.Generic;
using System.Linq;
using TariffConstructor.AdminApi.Dto.TariffAggragate;
using TariffConstructor.Domain.TariffModel;

namespace TariffConstructor.AdminApi.Mappers.TariffAggregate
{
    public static class IncludedProductInTariffMap
    {
        public static IncludedProductInTariffDto Map (this IncludedProductInTariff includedProductInTariff)
        {
            if(includedProductInTariff == null)
            {
                return null;
            }
            else
            {
                return new IncludedProductInTariffDto
                {
                    Id = includedProductInTariff.Id,
                    TariffId = includedProductInTariff.TariffId,
                    ProductId = includedProductInTariff.ProductId,
                    RelativeWeight = includedProductInTariff.RelativeWeight
                };
            }
        }

        public static IReadOnlyList<IncludedProductInTariffDto> Map (this IEnumerable<IncludedProductInTariff> includedProductInTariffs)
        {
            return includedProductInTariffs == null ? new List<IncludedProductInTariffDto>() : includedProductInTariffs.Select(Map).ToList();
        }
    }
}
