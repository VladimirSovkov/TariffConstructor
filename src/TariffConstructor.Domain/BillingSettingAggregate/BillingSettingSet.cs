using TariffConstructor.Domain.Abstractions;
using Billing.Services.Ordering.Domain.Subscriptions.SettingAggregate;

namespace TariffConstructor.Domain.BillingSettingAggregate
{
    /// <summary>
    ///     Зафиксированная настройка биллинга
    /// </summary>
    public class BillingSettingSet : Entity, ISettingSet
    {
        public BillingSettingSet(
            int billingSettingId, 
            string value )
        {
            BillingSettingId = billingSettingId;
            Value = value;
        }

        public int SettingsSetId { get; private set; }

        public int BillingSettingId { get; private set; }
        public virtual BillingSetting BillingSetting { get; private set; }

        public string SettingPublicId => BillingSetting.PublicId;
        public Setting Setting => BillingSetting.Setting;
        public string Value { get; private set; }


        protected BillingSettingSet()
        {
        }
    }
}
