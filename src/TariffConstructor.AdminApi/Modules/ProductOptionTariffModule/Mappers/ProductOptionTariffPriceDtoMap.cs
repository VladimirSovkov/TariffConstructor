﻿using System.Collections.Generic;
using System.Linq;
using TariffConstructor.Domain.ProductOptionTariffModel;
using TariffConstructor.Domain.ValueObjects;

namespace TariffConstructor.AdminApi.Modules.ProductOptionTariffModule.Dto
{
    public static class ProductOptionTariffPriceDtoMap
    {
        public static ProductOptionTariffPrice ToProductOptionTariffPrice(
            this ProductOptionTariffPriceDto productOptionTariffPriceDto)
        {
            if (productOptionTariffPriceDto == null)
            {
                return null;
            }
            else
            {
                return new ProductOptionTariffPrice(0,
                    new Price(productOptionTariffPriceDto.Price.Value, productOptionTariffPriceDto.Price.Currency),
                    new ProlongationPeriod(productOptionTariffPriceDto.Period.Value,
                        (PeriodUnit)productOptionTariffPriceDto.Period.periodUnit));
            }
        }

        public static List<ProductOptionTariffPrice> ToProductOptionTariffPrices(
            this IEnumerable<ProductOptionTariffPriceDto> productOptionTariffPriceDtos)
        {
            return productOptionTariffPriceDtos == null ? new List<ProductOptionTariffPrice>() :
                productOptionTariffPriceDtos.Select(ToProductOptionTariffPrice).ToList();
        }
    }
}
