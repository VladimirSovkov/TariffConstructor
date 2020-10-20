using TariffConstructor.Domain.SettingAggregate;

namespace Billing.Services.Ordering.Domain.Subscriptions.Settings.Types
{
    internal class AccumulativeBooleanSetting : BaseBooleanSetting
    {
        public AccumulativeBooleanSetting( string value, string code ) 
            : base( SettingType.AccumulativeBoolean, value, code )
        {
        }
    }
}
