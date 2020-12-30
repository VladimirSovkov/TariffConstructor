using TariffConstructor.AdminApi.Dto.ValueObject;
using TariffConstructor.Domain.ValueObjects;

namespace TariffConstructor.AdminApi.Mappers.ValueObject
{
    public static class ProlongationPeriodMap
    {
        public static ProlongationPeriodDto Map (this ProlongationPeriod prolongationPeriod)
        {
            if (prolongationPeriod == null)
            {
                return null;
            }
            else
            {
                return new ProlongationPeriodDto
                {
                    Value = prolongationPeriod.Value,
                    periodUnit = (int)prolongationPeriod.Unit
                };
            }
        }
    }
}
