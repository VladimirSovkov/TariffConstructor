using System.Collections.Generic;
using System.Linq;
using TariffConstructor.Domain.Settings;

namespace TariffConstructor.Domain.SettingModel
{ 
    public class SettingsBuilder
    {
        private readonly List<SettingData> _dataSettings;

        public SettingsBuilder()
        {
            _dataSettings = new List<SettingData>();
        }

        public SettingsBuilder SetDataSettings( IEnumerable<SettingData> dataSettings )
        {
            if ( dataSettings != null )
            {
                _dataSettings.AddRange( dataSettings );
            }

            return this;
        }

        public ISettingsContainer Build()
        {
            List<ISetting> settings = new List<ISetting>();

            foreach ( var settingDataGroup in _dataSettings.GroupBy( x => x.Code ) )
            {
                List<ISetting> implementedSettings = new List<ISetting>();
                foreach ( SettingData settingData in settingDataGroup )
                {
                    implementedSettings.Add( new SettingImplement( settingData ) );
                }

                ISetting aggregatedSetting =
                    implementedSettings.Aggregate( ( left, right ) => left.Aggregate( right ) );

                settings.Add( aggregatedSetting );
            }

            return new SettingsContainer( settings );
        }
    }
}
