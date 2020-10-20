using Billing.Services.Ordering.Domain.Subscriptions.SettingAggregate;

namespace Billing.Services.Ordering.Domain.Subscriptions.Settings.Types
{
    internal class AccumulativeMultiEnumSetting : BaseMultiEnumSetting
    {
        public AccumulativeMultiEnumSetting( string value, string code ) 
            : base( SettingType.AccumulativeMultiEnum, value, code )
        {
        }
    }
}
