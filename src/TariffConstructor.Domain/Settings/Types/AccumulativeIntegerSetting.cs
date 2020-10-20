using Billing.Services.Ordering.Domain.Subscriptions.SettingAggregate;

namespace Billing.Services.Ordering.Domain.Subscriptions.Settings.Types
{
    internal class AccumulativeIntegerSetting : BaseIntegerSetting
    {
        public AccumulativeIntegerSetting( string value, string code )
            : base( SettingType.AccumulativeInteger, value, code )
        {
        }
    }
}
