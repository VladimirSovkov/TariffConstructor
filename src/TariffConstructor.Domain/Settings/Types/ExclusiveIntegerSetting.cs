using Billing.Services.Ordering.Domain.Subscriptions.SettingAggregate;

namespace Billing.Services.Ordering.Domain.Subscriptions.Settings.Types
{
    internal class ExclusiveIntegerSetting : BaseIntegerSetting
    {
        public ExclusiveIntegerSetting( string value, string code ) 
            : base( SettingType.ExclusiveInteger, value, code, isAccumulative: false )
        {
        }
    }
}
