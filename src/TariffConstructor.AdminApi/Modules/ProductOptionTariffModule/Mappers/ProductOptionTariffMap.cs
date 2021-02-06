using System.Collections.Generic;
using System.Linq;
using TariffConstructor.AdminApi.Mappers.ProductOptionTariffMap.Dto;
using TariffConstructor.AdminApi.Modules.ProductOptionModule;
using TariffConstructor.AdminApi.Modules.ProductOptionTariffModule.Dto;
using TariffConstructor.Domain.ProductOptionTariffModel;

namespace TariffConstructor.AdminApi.Modules.ProductOptionTariffModule.Mappers
{
    public static class ProductOptionTariffMap
    {
        public static ProductOptionTariffDto Map(this ProductOptionTariff productOptionTariff)
        {
            if (productOptionTariff == null)
            {
                return null;
            }
            else
            {
                return new ProductOptionTariffDto
                {
                    Id = productOptionTariff.Id,
                    Name = productOptionTariff.Name,
                    ProductOption = productOptionTariff.ProductOption.Map(),
                    ProductOptionId = productOptionTariff.ProductOptionId,
                    Prices = productOptionTariff.Prices.Map().ToList()
                };
            }
        }

        public static IReadOnlyList<ProductOptionTariffDto> Map(this IEnumerable<ProductOptionTariff> productOptionTariffs)
        {
            return productOptionTariffs == null ? new List<ProductOptionTariffDto>() : productOptionTariffs.Select(Map).ToList();
        }
    }
}
