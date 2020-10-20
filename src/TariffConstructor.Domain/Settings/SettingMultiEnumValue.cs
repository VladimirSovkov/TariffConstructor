using System;
using System.Linq;

namespace Billing.Services.Ordering.Domain.Subscriptions.Settings
{
    internal class SettingMultiEnumValue
    {
        public string Value { get; private set; }
        public char Separator { get; private set; }

        public SettingMultiEnumValue( string value, char separator = ';' )
        {
            Value = value;
            Separator = separator;
        }

        public SettingMultiEnumValue( string[] values, char separator = ';' )
        {
            Value = Pack( values, separator );
            Separator = separator;
        }

        public static SettingMultiEnumValue operator+ ( SettingMultiEnumValue left, SettingMultiEnumValue right )
        {
            string[] leftValues = left.Unpack();
            string[] rightValues = right.Unpack();

            string[] values = leftValues.Union( rightValues ).Distinct().ToArray();

            string resultValue = Pack( values, left.Separator );

            return new SettingMultiEnumValue( resultValue, left.Separator );
        }

        /// <summary>
        ///     Проверяет, является ли текущее значение подмножеством otherValue
        /// </summary>
        /// <param name="otherValue">Сравниваемое множество</param>
        /// <returns>true - если текущее значение является подмножеством к otherValue, 
        /// false - если текущее значение не является подмножеством к otherValue</returns>
        public bool IsSubsetOf( SettingMultiEnumValue otherValue )
        {
            string[] currentValues = Unpack();
            string[] otherValues = otherValue.Unpack();

            return !currentValues.Except( otherValues ).Any();
        }

        public string[] Unpack()
        {
            if ( String.IsNullOrEmpty( Value ) )
            {
                return new string[0];
            }

            return Value
                .Split( Separator )
                .Select( x => x.Trim() )
                .Where( x => !String.IsNullOrEmpty( x ) )
                .ToArray();
        }

        public override string ToString()
        {
            return Value;
        }

        private static string Pack( string[] values, char separator )
        {
            return String.Join( separator.ToString(), values );
        }
    }
}
