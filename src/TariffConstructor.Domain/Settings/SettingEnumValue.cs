using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Billing.Services.Ordering.Domain.Subscriptions.Settings
{
    internal class SettingEnumValue
    {
        private const string ArrayPattern = @"^\[(?<VALUE>(.*))\]$";

        public string Value { get; private set; }
        public char Separator { get; private set; }

        public SettingEnumValue( string value, char separator = ';' )
        {
            Value = value;
            Separator = separator;
        }

        public object ToPublicValue()
        {
            if ( IsArray( Value ) )
            {
                return Unpack( Value, Separator );
            }

            return Value;
        }

        public bool Contains( string value )
        {
            return Unpack( Value, Separator ).Contains( value );
        }

        public override string ToString()
        {
            return Value;
        }

        private static bool IsArray( string value )
        {
            return value != null && Regex.IsMatch( value, ArrayPattern );
        }

        private static string GetRawValueFromArray( string value )
        {
            return Regex.Match( value, ArrayPattern ).Groups[ "VALUE" ].Value;
        }

        private static string[] Unpack( string value, char separator )
        {
            string rawValue = IsArray( value ) ? GetRawValueFromArray( value ) : value;

            return rawValue
                .Split( separator )
                .Select( x => x.Trim() )
                .Where( x => !String.IsNullOrEmpty( x ) )
                .ToArray();
        }
    }
}
