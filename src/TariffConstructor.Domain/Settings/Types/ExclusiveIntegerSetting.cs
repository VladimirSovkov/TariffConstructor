using TariffConstructor.Domain.SettingModel;

namespace TariffConstructor.Domain.Settings.Types
{
    internal class ExclusiveIntegerSetting : BaseIntegerSetting
    {
        public ExclusiveIntegerSetting( string value, string code ) 
            : base( SettingType.ExclusiveInteger, value, code, isAccumulative: false )
        {
        }
    }
}
