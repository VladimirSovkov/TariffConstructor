using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TariffConstructor.AdminApi.Dto.TariffAggragate;
using TariffConstructor.Domain.TariffModel;

namespace TariffConstructor.AdminApi.Mappers.TariffMap
{
    public static class TariffTestPeriodMap
    {
        public static TariffTestPeriodDto Map(this TariffTestPeriod tariffTestPeriod)
        {
            if (tariffTestPeriod == null)
            {
                return null;
            }
            else
            {
                return new TariffTestPeriodDto
                {
                    Unit = (int)tariffTestPeriod.Unit,
                    Value = tariffTestPeriod.Value
                };
            }
        }

        public static IReadOnlyList<TariffTestPeriodDto> Map(this IEnumerable<TariffTestPeriod> tariffTestPeriods)
        {
            return tariffTestPeriods == null ? new List<TariffTestPeriodDto>() : tariffTestPeriods.Select(Map).ToList();
        }
    }
}
