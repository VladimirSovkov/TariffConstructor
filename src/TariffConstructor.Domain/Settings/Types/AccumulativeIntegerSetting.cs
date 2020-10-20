using TariffConstructor.Domain.SettingAggregate;

namespace TariffConstructor.Domain.Settings.Types
{
    internal class AccumulativeIntegerSetting : BaseIntegerSetting
    {
        public AccumulativeIntegerSetting( string value, string code )
            : base( SettingType.AccumulativeInteger, value, code )
        {
        }
    }
}
