using TariffConstructor.Domain.SettingAggregate;

namespace TariffConstructor.Domain.Settings.Types
{
    internal class ExclusiveBooleanSetting : BaseBooleanSetting
    {
        public ExclusiveBooleanSetting( string value, string code ) 
            : base( SettingType.ExclusiveBoolean, value, code, isAccumulative: false )
        {
        }
    }
}
