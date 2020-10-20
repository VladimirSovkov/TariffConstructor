using System;
using TariffConstructor.Domain.SettingAggregate;

namespace TariffConstructor.Domain.Settings.Types
{
    internal abstract class BaseMultiEnumSetting : BaseSetting
    {
        protected BaseMultiEnumSetting(
            SettingType type,
            string value,
            string code,
            bool isAccumulative = true )
        {
            Type = type;
            Code = code;
            RawValue = value;
            IsAccumulative = isAccumulative;
        }

        public override bool IsValid( string minValue, string maxValue, bool isRequired )
        {
            if ( isRequired && String.IsNullOrEmpty( RawValue ) )
            {
                return false;
            }

            SettingMultiEnumValue value = new SettingMultiEnumValue( RawValue );
            SettingMultiEnumValue extractedMinValue = new SettingMultiEnumValue( minValue );
            SettingMultiEnumValue extractedMaxValue = new SettingMultiEnumValue( maxValue );

            // Текущее значение перечислимого типа должно быть надмножеством minValue и подмножеством maxValue
            return extractedMinValue.IsSubsetOf( value ) && value.IsSubsetOf( extractedMaxValue );
        }

        public override void Parse<TValue>( TValue value )
        {
            string[] baseValue = value as string[];

            if ( baseValue == null )
            {
                throw new ArgumentException( $"value must be '{typeof( string[] ).FullName}'" );
            }

            SettingMultiEnumValue enumValue = new SettingMultiEnumValue( baseValue );
            RawValue = enumValue.Value;
        }

        public override object Value => new SettingMultiEnumValue( RawValue ).Unpack();

        protected override ISetting MergeSettings( ISetting left, ISetting right )
        {
            SettingMultiEnumValue leftValue = new SettingMultiEnumValue( left.RawValue );
            SettingMultiEnumValue rightValue = new SettingMultiEnumValue( right.RawValue );

            RawValue = ( leftValue + rightValue ).ToString();

            return this;
        }
    }
}
