using System.Collections.Generic;
using System.Linq;
using TariffConstructor.AdminApi.Dto.TariffAggragate;
using TariffConstructor.AdminApi.Mappers.ProductMap;
using TariffConstructor.Domain.TariffModel;

namespace TariffConstructor.AdminApi.Mappers.TariffMap
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
                    RelativeWeight = includedProductInTariff.RelativeWeight,
                    Product = includedProductInTariff.Product.Map()
                };
            }
        }

        public static IReadOnlyList<IncludedProductInTariffDto> Map (this IEnumerable<IncludedProductInTariff> includedProductInTariffs)
        {
            return includedProductInTariffs == null ? new List<IncludedProductInTariffDto>() : includedProductInTariffs.Select(Map).ToList();
        }
    }
}
