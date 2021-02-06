using System.Collections.Generic;
using System.Linq;
using TariffConstructor.AdminApi.Modules.TariffModule.Dto;
using TariffConstructor.Domain.TariffModel;
using TariffConstructor.Domain.ValueObjects;

namespace TariffConstructor.AdminApi.Mappers.TariffMap
{
    public static class TariffAdvancePriceDtoMap
    {
        public static TariffAdvancePrice ToTariffAdvancePrice(this TariffAdvancePriceDto tariffAdvancePriceDto)
        {
            if (tariffAdvancePriceDto == null)
            {
                return null;
            }
            else
            {
                return new TariffAdvancePrice(new Price(tariffAdvancePriceDto.Price.Value, tariffAdvancePriceDto.Price.Currency),
                    new ProlongationPeriod(tariffAdvancePriceDto.Period.Value, (PeriodUnit)tariffAdvancePriceDto.Period.periodUnit));
            }
        }

        public static List<TariffAdvancePrice> ToTariffAdvancePrices(this IEnumerable<TariffAdvancePriceDto> tariffPriceDtos)
        {
            return tariffPriceDtos == null ? new List<TariffAdvancePrice>() : tariffPriceDtos.Select(ToTariffAdvancePrice).ToList();
        }
    }
}
