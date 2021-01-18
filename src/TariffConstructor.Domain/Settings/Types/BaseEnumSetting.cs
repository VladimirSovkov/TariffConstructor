using System;
using TariffConstructor.Domain.SettingModel;

namespace TariffConstructor.Domain.Settings.Types
{
    internal abstract class BaseEnumSetting : BaseSetting
    {
        protected BaseEnumSetting(
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

            if ( !String.IsNullOrEmpty( maxValue ) && !String.IsNullOrEmpty( RawValue ) )
            {
                return new SettingEnumValue( maxValue ).Contains( RawValue );
            }

            if ( !String.IsNullOrEmpty( minValue ) && !String.IsNullOrEmpty( RawValue ) )
            {
                return new SettingEnumValue( minValue ).Contains( RawValue );
            }

            return true;
        }

        public override void Parse<TValue>( TValue value )
        {
            if ( object.Equals( value, default( TValue ) ) )
            {
                RawValue = null;
            }
            else
            {
                string baseValue = value as string;

                RawValue = baseValue ?? throw new ArgumentException( $"value must be '{typeof( string ).FullName}'" );
            }
        }

        public override object Value => new SettingEnumValue( RawValue ).ToPublicValue();

        protected override ISetting MergeSettings( ISetting left, ISetting right )
        {
            throw new NotImplementedException();
        }
    }
}
