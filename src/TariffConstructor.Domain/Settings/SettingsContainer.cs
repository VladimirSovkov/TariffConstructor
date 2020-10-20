using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TariffConstructor.Domain.Settings
{
    public class SettingsContainer : ISettingsContainer
    {
        private readonly IReadOnlyList<ISetting> _settings;

        public SettingsContainer( List<ISetting> settings )
        {
            _settings = settings;
        }

        public string ToJson()
        {
            if ( !_settings.Any() )
            {
                return null;
            }

            return JsonConvert.SerializeObject( ToDictionary() );
        }

        public IDictionary<string, object> ToDictionary()
        {
            if ( !_settings.Any() )
            {
                return null;
            }

            Dictionary<string, object> settingsObject = new Dictionary<string, object>();

            foreach ( ISetting setting in _settings )
            {
                settingsObject.Add( setting.Code, setting.Value );
            }

            return settingsObject;
        }
    }
}
