using TariffConstructor.Domain.SettingModel;

namespace TariffConstructor.Domain.Settings
{
    public class SettingData
    {
        public SettingData( SettingType type, string code, string value )
        {
            Type = type;
            Code = code;
            Value = value;
        }
        public SettingType Type { get; }
        public string Code { get; }
        public string Value { get; set; }
    }
}
