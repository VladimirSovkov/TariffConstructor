using System.Collections.Generic;
using System.Linq;
using TariffConstructor.AdminApi.Modules.ProductOptionModule;
using TariffConstructor.AdminApi.Modules.TariffModule.Dto;
using TariffConstructor.Domain.TariffModel;

namespace TariffConstructor.AdminApi.Mappers.TariffMap
{
    public static class IncludedProductOptionInTariffMap
    {
        public  static IncludedProductOptionInTariffDto Map (this IncludedProductOptionInTariff includedProductOptionInTariff)
        {
            if (includedProductOptionInTariff == null)
            {
                return null;
            }
            else
            {
                return new IncludedProductOptionInTariffDto
                {
                    Id = includedProductOptionInTariff.Id,
                    Quantity = includedProductOptionInTariff.Quantity,
                    TariffId = includedProductOptionInTariff.TariffId,
                    ProductOptionId = includedProductOptionInTariff.ProductOptionId,
                    ProductOption = includedProductOptionInTariff.ProductOption.Map()
                };
            }
        }

        public static IReadOnlyList<IncludedProductOptionInTariffDto> Map(this IEnumerable<IncludedProductOptionInTariff> includedProductOptionInTariffs)
        {
            return includedProductOptionInTariffs == null ? new List<IncludedProductOptionInTariffDto>() : includedProductOptionInTariffs.Select(Map).ToList();
        }
    }
}
