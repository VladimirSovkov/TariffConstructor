using TariffConstructor.Domain.SettingModel;

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
