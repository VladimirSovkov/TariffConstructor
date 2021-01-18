using TariffConstructor.Domain.SettingModel;

namespace TariffConstructor.Domain.Settings.Types
{
    internal class ExclusiveStringSetting : BaseStringSetting
    {
        public ExclusiveStringSetting( string value, string code )
            : base( SettingType.ExclusiveString, value, code, isAccumulative: false )
        {
        }
    }
}
