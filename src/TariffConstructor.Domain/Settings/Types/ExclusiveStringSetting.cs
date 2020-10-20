using Billing.Services.Ordering.Domain.Subscriptions.SettingAggregate;

namespace Billing.Services.Ordering.Domain.Subscriptions.Settings.Types
{
    internal class ExclusiveStringSetting : BaseStringSetting
    {
        public ExclusiveStringSetting( string value, string code )
            : base( SettingType.ExclusiveString, value, code, isAccumulative: false )
        {
        }
    }
}
