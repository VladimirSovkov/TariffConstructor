using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TariffConstructor.AdminApi.Dto.TariffAggragate;
using TariffConstructor.Domain.TariffModel;
using TariffConstructor.Domain.ValueObjects;

namespace TariffConstructor.AdminApi.Mappers.TariffMap
{
    public static class TariffPriceDtoMap
    {
        public static TariffPrice ToTariffPrice(this TariffPriceDto priceDto)
        {
            if (priceDto == null)
            {
                return null;
            }
            else
            {

                return new TariffPrice(new Price(priceDto.Price.Value, priceDto.Price.Currency),
                    new ProlongationPeriod(priceDto.Period.Value, (PeriodUnit)priceDto.Period.periodUnit));
            }
        }

        public static List<TariffPrice> ToTariffPrices(this IEnumerable<TariffPriceDto> tariffPriceDtos)
        {
            return tariffPriceDtos == null ? new List<TariffPrice>() : tariffPriceDtos.Select(ToTariffPrice).ToList();
        }
    }
}
