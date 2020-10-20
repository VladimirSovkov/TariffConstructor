using System;
using TariffConstructor.Domain.SettingAggregate;

namespace TariffConstructor.Domain.Settings.Types
{
    internal abstract class BaseIntegerSetting : BaseSetting
    {
        protected BaseIntegerSetting(
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
            int value = (int) Value;

            if ( !String.IsNullOrEmpty( minValue ) )
            {
                int extractedMinValue = Convert.ToInt32( minValue );
                if ( value < extractedMinValue )
                {
                    return false;
                }
            }

            if ( !String.IsNullOrEmpty( maxValue ) )
            {
                int extractedMaxValue = Convert.ToInt32( maxValue );
                if ( value > extractedMaxValue )
                {
                    return false;
                }
            }

            return true;
        }

        public override void Parse<TValue>( TValue value )
        {
            if ( !( value is int ) )
            {
                throw new ArgumentException( $"value must be '{typeof( int ).FullName}'" );
            }

            RawValue = Convert.ToString( value );
        }

        public override object Value => Convert.ToInt32( RawValue );

        protected override ISetting MergeSettings( ISetting left, ISetting right )
        {
            RawValue = Convert.ToString( (int) left.Value + (int) right.Value );

            return this;
        }
    }
}
