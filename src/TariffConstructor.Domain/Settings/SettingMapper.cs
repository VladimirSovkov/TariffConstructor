using TariffConstructor.Domain.ApplicationSettingAggregate;

namespace TariffConstructor.Domain.Settings
{
    public static class SettingMapper
    {
        public static SettingData ToSettingData( this ApplicationSettingValue applicationSettingValue )
        {
            if ( applicationSettingValue == null )
            {
                return null;
            }

            return new SettingData(
                applicationSettingValue.ApplicationSetting.Setting.Type,
                applicationSettingValue.ApplicationSetting.Setting.Code,
                applicationSettingValue.Value );
        }

        public static SettingData ToSettingData( this ApplicationSetting applicationSetting )
        {
            if ( applicationSetting.DefaultValue == null )
            {
                return null;
            }

            return new SettingData(
                applicationSetting.Setting.Type,
                applicationSetting.Setting.Code,
                applicationSetting.DefaultValue );
        }
    }
}
