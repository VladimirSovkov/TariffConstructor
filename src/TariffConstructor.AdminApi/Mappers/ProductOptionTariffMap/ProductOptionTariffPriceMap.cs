using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TariffConstructor.AdminApi.Dto.ProductOptionTariff;
using TariffConstructor.AdminApi.Mappers.ValueObjectMap;
using TariffConstructor.Domain.ProductOptionTariffModel;

namespace TariffConstructor.AdminApi.Mappers.ProductOptionTariffMap
{
    public static class ProductOptionTariffPriceMap
    {
        public static ProductOptionTariffPriceDto Map(this ProductOptionTariffPrice productOptionTariffPrice)
        {
            if (productOptionTariffPrice == null)
            {
                return null;
            }
            else
            {
                return new ProductOptionTariffPriceDto
                {
                    Id = productOptionTariffPrice.Id,
                    Period = productOptionTariffPrice.Period.Map(),
                    Price = productOptionTariffPrice.Price.Map()
                };
            }
        }

        public static IReadOnlyList<ProductOptionTariffPriceDto> Map(this IEnumerable<ProductOptionTariffPrice> productOptionTariffPrices)
        {
            return productOptionTariffPrices == null ? new List<ProductOptionTariffPriceDto>() : productOptionTariffPrices.Select(Map).ToList();
        }
    }
}
