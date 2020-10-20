using TariffConstructor.Domain.SettingAggregate;

namespace TariffConstructor.Domain.Settings.Types
{
    internal class AccumulativeBooleanSetting : BaseBooleanSetting
    {
        public AccumulativeBooleanSetting( string value, string code ) 
            : base( SettingType.AccumulativeBoolean, value, code )
        {
        }
    }
}
