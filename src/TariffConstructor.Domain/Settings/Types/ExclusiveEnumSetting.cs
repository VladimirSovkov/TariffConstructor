using Billing.Services.Ordering.Domain.Subscriptions.SettingAggregate;

namespace Billing.Services.Ordering.Domain.Subscriptions.Settings.Types
{
    internal class ExclusiveEnumSetting : BaseEnumSetting
    {
        public ExclusiveEnumSetting( string value, string code )
            : base( SettingType.ExclusiveEnum, value, code, false )
        {
        }
    }
}
