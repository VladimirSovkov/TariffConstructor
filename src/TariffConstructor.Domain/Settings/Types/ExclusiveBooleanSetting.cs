using Billing.Services.Ordering.Domain.Subscriptions.SettingAggregate;

namespace Billing.Services.Ordering.Domain.Subscriptions.Settings.Types
{
    internal class ExclusiveBooleanSetting : BaseBooleanSetting
    {
        public ExclusiveBooleanSetting( string value, string code ) 
            : base( SettingType.ExclusiveBoolean, value, code, isAccumulative: false )
        {
        }
    }
}
