using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TariffConstructor.Domain.TariffModel;

namespace TariffConstructor.AdminApi.Modules.AvailableTariffForUpgradeModule
{
    public static class AvailableTariffForUpgradeMapper
    {
        public static AvailableTariffForUpgradeDto Map(this AvailableTariffForUpgrade availableTariffForUpgrade)
        {
            if (availableTariffForUpgrade == null)
            {
                return null;
            }
            return new AvailableTariffForUpgradeDto
            {
                Id = availableTariffForUpgrade.Id,
                FromTariffId = availableTariffForUpgrade.FromTariffId,
                ToTariffId = availableTariffForUpgrade.ToTariffId,
            };
        }

        public static IReadOnlyList<AvailableTariffForUpgradeDto> Map(this IEnumerable<AvailableTariffForUpgrade> availableTariffForUpgrades)
        {
            return availableTariffForUpgrades == null ? new List<AvailableTariffForUpgradeDto>() : availableTariffForUpgrades.Select(Map).ToList();
        }
    }
}
