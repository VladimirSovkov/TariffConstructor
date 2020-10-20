using TariffConstructor.Domain.SettingAggregate;

namespace TariffConstructor.Domain.Settings.Types
{
    internal class AccumulativeMoneySetting : BaseMoneySetting
    {
        public AccumulativeMoneySetting( string value, string code ) 
            : base( SettingType.AccumulativeMoney, value, code )
        {
        }
    }
}
