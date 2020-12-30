﻿using System.Collections.Generic;
using System.Linq;
using TariffConstructor.AdminApi.Dto.TariffAggragate;
using TariffConstructor.AdminApi.Mappers.ValueObject;
using TariffConstructor.Domain.TariffAggregate;

namespace TariffConstructor.AdminApi.Mappers.TariffAggregate
{
    public static class TariffPriceMap
    {
        public static TariffPriceDto Map (this TariffPrice tariffPrice)
        {
            if (tariffPrice == null)
            {
                return null;
            }
            else
            {
                return new TariffPriceDto
                {
                    Id = tariffPrice.Id,
                    Price = tariffPrice.Price.Map(),
                    Period = tariffPrice.Period.Map(),
                    TariffId = tariffPrice.TariffId
                };
            }
        }

        public static IReadOnlyList<TariffPriceDto> Map (this IEnumerable<TariffPrice> tariffPrices)
        {
            return tariffPrices == null ? new List<TariffPriceDto>() : tariffPrices.Select(Map).ToList();
        }
    }
}
