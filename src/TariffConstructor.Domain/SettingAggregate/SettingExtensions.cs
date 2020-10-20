using TariffConstructor.Domain.Settings;

namespace TariffConstructor.Domain.SettingAggregate
{
    public static class SettingExtensions
    {
        public static object ExtractValue( this ISettingPreset settingPreset, string value )
        {
            if ( settingPreset == null )
            {
                return null;
            }

            ISetting setting = new SettingImplement( settingPreset.Setting.Type, settingPreset.Setting.Code, value );

            return setting.Value;
        }

        public static object ExtractValue( this ISettingSet settingPreset, string value )
        {
            if ( settingPreset == null )
            {
                return null;
            }

            ISetting setting = new SettingImplement( settingPreset.Setting.Type, settingPreset.Setting.Code, value );

            return setting.Value;
        }
    }
}
