using TariffConstructor.AdminApi.Dto.ValueObject;
using TariffConstructor.Domain.ValueObjects;

namespace TariffConstructor.AdminApi.Mappers.ValueObject
{
    public static class PriceMap
    {
        public static PriceDto Map (this Price price)
        {
            if (price == null)
            {
                return null;
            }
            else
            {
                return new PriceDto
                {
                    Value = price.Value,
                    Currency = price.Currency
                };
            }
        }
    }
}
