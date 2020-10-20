using System;
using Billing.Services.Ordering.Domain.Subscriptions.SettingAggregate;

namespace Billing.Services.Ordering.Domain.Subscriptions.Settings.Types
{
    internal abstract class BaseSetting : ISetting
    {
        /// <summary>
        ///     Объединяет две настройки в одну
        /// </summary>
        public ISetting Aggregate( ISetting right )
        {
            if ( !IsAccumulative )
            {
                throw new InvalidOperationException( $"Setting of type [{Type:G}] is not accumulative" );
            }

            ISetting left = this;

            if ( left.Type != right.Type || left.Code != right.Code )
            {
                throw new InvalidOperationException( "Can't aggregate different settings: " +
                                                     $"Left is [Type:{left.Type:G}, Code:{left.Code}], " +
                                                     $"Right is [Type:{right.Type:G}, Code:{right.Code}]" );
            }

            return MergeSettings( left, right );
        }

        /// <summary>
        ///     Проверяет, укладывается ли текущее значение настройки в указанные рамки
        /// </summary>
        public abstract bool IsValid( string minValue, string maxValue, bool isRequired );

        public abstract void Parse<TValue>( TValue value );

        public SettingType Type { get; set; }
        public string Code { get; set; }
        public string RawValue { get; set; }
        public abstract object Value { get; }

        /// <summary>
        ///     Логика объединения настроек определяется в конкретной реализации
        /// </summary>
        protected abstract ISetting MergeSettings( ISetting left, ISetting right );

        /// <summary>
        ///     Настройка объединяемая
        /// </summary>
        protected bool IsAccumulative;
    }
}
