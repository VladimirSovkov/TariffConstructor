using System;
using TariffConstructor.Domain.SettingAggregate;

namespace TariffConstructor.Domain.Settings.Types
{
    internal abstract class BaseBooleanSetting : BaseSetting
    {
        protected BaseBooleanSetting(
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
            // У флага нет границ, он всегда валидный
            return true;
        }

        public override void Parse<TValue>( TValue value )
        {
            if ( !( value is bool ) )
            {
                throw new ArgumentException( $"value must be '{typeof( bool ).FullName}'" );
            }

            RawValue = Convert.ToString( Convert.ToBoolean( value ) );
        }

        public override object Value => !String.IsNullOrEmpty( RawValue ) && Convert.ToBoolean( RawValue );

        /// <summary>
        ///     Реализация по-умолчанию возвращает настройку с приоритетом true > false.
        ///     Если одна из настроек имеет значение true, то вернется true
        /// </summary>
        protected override ISetting MergeSettings( ISetting left, ISetting right )
        {
            RawValue = Convert.ToString( (bool) left.Value || (bool) right.Value );

            return this;
        }
    }
}
