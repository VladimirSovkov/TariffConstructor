using TariffConstructor.Domain.SettingAggregate;

namespace TariffConstructor.Domain.Settings
{
    public interface ISetting
    {
        ISetting Aggregate( ISetting right );
        bool IsValid( string minValue, string maxValue, bool isRequired = true );
        void Parse<TValue>( TValue value );

        SettingType Type { get; set; }
        string Code { get; set; }
        string RawValue { get; set; }
        object Value { get; }
    }
}
