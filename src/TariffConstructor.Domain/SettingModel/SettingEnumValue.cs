using TariffConstructor.Toolkit.Abstractions;

namespace TariffConstructor.Domain.SettingModel
{
    public class SettingEnumValue : Entity
    {
        public SettingEnumValue( string code, string name )
        {
            Code = code;
            Name = name;
        }

        public int SettingId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        protected SettingEnumValue()
        {
        }
    }
}
