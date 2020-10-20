using System;
using System.Globalization;
using System.Text.RegularExpressions;
using TariffConstructor.Domain.SettingAggregate;
using TariffConstructor.Domain.ValueObjects;

namespace TariffConstructor.Domain.Settings.Types
{
    internal abstract class BaseMoneySetting : BaseSetting
    {
        /// <summary>
        ///     1500.0000:RUB
        /// </summary>
        private const string MoneyPattern = @"^(?<AMOUNT>([\d]+([.,][\d]+)?)):(?<CURRENCY>[A-Z]{3})$";

        protected BaseMoneySetting(
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

        public override object Value => Extract( RawValue );

        public override bool IsValid( string minValue, string maxValue, bool isRequired )
        {
            Price value = (Price) Value;

            if ( !String.IsNullOrEmpty( minValue ) )
            {
                Price extractedMinValue = Extract( minValue );
                if ( value < extractedMinValue )
                {
                    return false;
                }
            }

            if ( !String.IsNullOrEmpty( maxValue ) )
            {
                Price extractedMaxValue = Extract( maxValue );
                if ( value > extractedMaxValue )
                {
                    return false;
                }
            }

            return true;
        }

        public override void Parse<TValue>( TValue value )
        {
            Price price = value as Price;

            if ( price == null )
            {
                throw new ArgumentException( $"value must be '{typeof( Price ).FullName}'" );
            }

            RawValue = Pack( price );
        }

        protected Price Extract( string value )
        {
            if ( String.IsNullOrEmpty( value ) )
            {
                return null;
            }

            Match match = Regex.Match( value, MoneyPattern );
            if ( !match.Success )
            {
                throw new InvalidCastException( $"'{value}' is not a type of money" );
            }

            return new Price(
                Convert.ToDecimal( match.Groups[ "AMOUNT" ].Value, CultureInfo.InvariantCulture ),
                Convert.ToString( match.Groups[ "CURRENCY" ].Value ) );
        }

        protected string Pack( Price value )
        {
            return $"{value.Value.ToString( CultureInfo.InvariantCulture )}:{value.Currency}";
        }

        protected override ISetting MergeSettings( ISetting left, ISetting right )
        {
            Price mergedPrice = (Price) left.Value + (Price) right.Value;

            RawValue = Pack( mergedPrice );

            return this;
        }
    }
}
