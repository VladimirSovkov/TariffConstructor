using TariffConstructor.Domain.SettingModel;

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
