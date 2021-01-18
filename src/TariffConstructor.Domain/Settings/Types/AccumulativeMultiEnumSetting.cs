using TariffConstructor.Domain.SettingModel;

namespace TariffConstructor.Domain.Settings.Types
{
    internal class AccumulativeMultiEnumSetting : BaseMultiEnumSetting
    {
        public AccumulativeMultiEnumSetting( string value, string code ) 
            : base( SettingType.AccumulativeMultiEnum, value, code )
        {
        }
    }
}
