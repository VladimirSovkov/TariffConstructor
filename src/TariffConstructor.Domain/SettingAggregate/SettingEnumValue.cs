using TariffConstructor.Domain.Abstractions;

namespace TariffConstructor.Domain.SettingAggregate
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
