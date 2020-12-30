using System.Collections.Generic;
using System.Linq;
using TariffConstructor.AdminApi.Dto.TariffAggragate;
using TariffConstructor.AdminApi.Mappers.ValueObject;
using TariffConstructor.Domain.TariffAggregate;

namespace TariffConstructor.AdminApi.Mappers.TariffAggregate
{
    public static class TariffAdvancePriceMap
    {
        public static TariffAdvancePriceDto Map(this TariffAdvancePrice tariffAdvancePrice)
        {
            if (tariffAdvancePrice == null)
            {
                return null;
            }
            else
            {
                return new TariffAdvancePriceDto
                {
                    Id = tariffAdvancePrice.Id,
                    Price = tariffAdvancePrice.Price.Map(),
                    Period = tariffAdvancePrice.Period.Map(),
                    TariffId = tariffAdvancePrice.TariffId
                };
            }
        }

        public static IReadOnlyList<TariffAdvancePriceDto> Map (this IEnumerable<TariffAdvancePrice> tariffAdvancePrices)
        {
            return tariffAdvancePrices == null ? new List<TariffAdvancePriceDto>() : tariffAdvancePrices.Select(Map).ToList();
        }
    }
}
