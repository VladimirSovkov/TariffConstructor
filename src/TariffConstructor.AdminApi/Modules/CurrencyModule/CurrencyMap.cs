using System.Collections.Generic;
using System.Linq;
using TariffConstructor.Domain.CurrencyModel;

namespace TariffConstructor.AdminApi.Modules.CurrencyModule
{
    public static class CurrencyMap
    {
        public static CurrencyDto Map(this Currency currency)
        {
            if (currency == null)
            {
                return null;
            }
            else
            {
                return new CurrencyDto
                {
                    Id = currency.Id,
                    Code = currency.Code,
                    Name = currency.Name
                };
            }
        }

        public static IReadOnlyList<CurrencyDto> Map(this IEnumerable<Currency> currencies)
        {
            return currencies == null ? new List<CurrencyDto>() : currencies.Select(Map).ToList();
        }
    }
}
