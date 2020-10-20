using System;
using TariffConstructor.Domain.SettingAggregate;

namespace TariffConstructor.Domain.Settings.Types
{
    internal abstract class BaseStringSetting : BaseSetting
    {
        protected BaseStringSetting(
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
                if ( !( value is string ) )
                {
                    throw new ArgumentException( $"value must be '{typeof( string ).FullName}'" );
                }

                RawValue = Convert.ToString( value );
            }
        }

        public override object Value => RawValue;

        protected override ISetting MergeSettings( ISetting left, ISetting right )
        {
            throw new NotImplementedException();
        }
    }
}
