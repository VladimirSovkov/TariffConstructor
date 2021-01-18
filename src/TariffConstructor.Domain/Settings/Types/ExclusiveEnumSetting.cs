using TariffConstructor.Domain.SettingModel;

namespace TariffConstructor.Domain.Settings.Types
{
    internal class ExclusiveEnumSetting : BaseEnumSetting
    {
        public ExclusiveEnumSetting( string value, string code )
            : base( SettingType.ExclusiveEnum, value, code, false )
        {
        }
    }
}
