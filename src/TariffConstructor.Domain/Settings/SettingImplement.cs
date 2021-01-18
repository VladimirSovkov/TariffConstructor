using System;
using System.ComponentModel;
using TariffConstructor.Domain.SettingModel;
using TariffConstructor.Domain.Settings.Types;

namespace TariffConstructor.Domain.Settings
{
    public class SettingImplement : ISetting
    {
        private readonly ISetting _setting;

        public SettingImplement( SettingData data )
        {
            _setting = GetSettingImplementation( data.Type, data.Code, data.Value );
        }

        public SettingImplement( 
            SettingType type, 
            string code, 
            string value )
        {
            _setting = GetSettingImplementation( type, code, value );
        }

        public SettingImplement( Setting setting )
        {
            _setting = GetSettingImplementation( setting.Type, setting.Code, null );
        }

        public ISetting Aggregate( ISetting right )
        {
            return _setting.Aggregate( right );
        }

        public bool IsValid( string minValue, string maxValue, bool isRequired = true )
        {
            return _setting.IsValid( minValue, maxValue, isRequired );
        }

        public void Parse<TValue>( TValue value )
        {
            _setting.Parse( value );
        }

        public SettingType Type
        {
            get => _setting.Type;
            set => throw new NotImplementedException();
        }

        public string Code
        {
            get => _setting.Code;
            set => throw new NotImplementedException();
        }

        public string RawValue
        {
            get => _setting.RawValue;
            set => _setting.RawValue = value;
        }

        public object Value => _setting.Value;

        private static ISetting GetSettingImplementation( SettingType type, string code, string value )
        {
            switch ( type )
            {
                case SettingType.AccumulativeInteger:
                    return new AccumulativeIntegerSetting( value, code );

                case SettingType.AccumulativeBoolean:
                    return new AccumulativeBooleanSetting( value, code );

                case SettingType.AccumulativeMultiEnum:
                    return new AccumulativeMultiEnumSetting( value, code );

                case SettingType.ExclusiveEnum:
                    return new ExclusiveEnumSetting( value, code );

                case SettingType.AccumulativeMoney:
                    return new AccumulativeMoneySetting( value, code );

                case SettingType.ExclusiveInteger:
                    return new ExclusiveIntegerSetting( value, code );

                case SettingType.ExclusiveBoolean:
                    return new ExclusiveBooleanSetting( value, code );

                case SettingType.ExclusiveString:
                    return new ExclusiveStringSetting( value, code );

                case SettingType.Unknown:
                default:
                    throw new InvalidEnumArgumentException( $"Unknown setting type: {type:G}" );
            }
        }
    }
}
