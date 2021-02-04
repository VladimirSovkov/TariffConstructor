using TariffConstructor.Toolkit.Abstractions;

namespace TariffConstructor.Domain.TariffModel
{
    public class AvailableTariffForUpgrade : MultitenancyEntity, IAggregateRoot
    {
        public AvailableTariffForUpgrade( int fromTariffId, int toTariffId )
        {
            FromTariffId = fromTariffId;
            ToTariffId = toTariffId;
        }

        public int FromTariffId { get; private set; }
        public int ToTariffId { get; private set; }

        protected AvailableTariffForUpgrade()
        {
        }

        public void SetFromTariffId(int fromTariffId)
        {
            FromTariffId = fromTariffId;
        }

        public void SetToTariffId(int toTariffId)
        {
            ToTariffId = toTariffId;
        }
    }
}
