using Billing.Services.Ordering.Domain.Subscriptions.SettingAggregate;

namespace Billing.Services.Ordering.Domain.Subscriptions.Settings.Types
{
    internal class AccumulativeMoneySetting : BaseMoneySetting
    {
        public AccumulativeMoneySetting( string value, string code ) 
            : base( SettingType.AccumulativeMoney, value, code )
        {
        }
    }
}
