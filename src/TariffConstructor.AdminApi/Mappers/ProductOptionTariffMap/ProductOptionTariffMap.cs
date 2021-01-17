﻿using System.Collections.Generic;
using System.Linq;
using TariffConstructor.AdminApi.Dto.ProductOptionTariff;
using TariffConstructor.AdminApi.Mappers.ProductOptionAggregate;
using TariffConstructor.Domain.ProductOptionTariffAggregate;

namespace TariffConstructor.AdminApi.Mappers.ProductOptionTariffMap
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