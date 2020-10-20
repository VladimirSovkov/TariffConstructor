using System;
using System.Collections.Generic;
using TariffConstructor.Toolkit.Abstractions;

namespace TariffConstructor.Domain.ValueObjects
{
    public class Price : ValueObject<Price>
    {
        public decimal Value { get; private set; }

        public string Currency { get; private set; }

        public Price( decimal value, string currency )
        {
            if ( value < 0 )
            {
                throw new InvalidOperationException( "price value can't has negative value" );
            }

            if ( String.IsNullOrEmpty( currency ) )
            {
                throw new InvalidOperationException( "price currency not specified" );
            }

            Value = value;
            Currency = currency;
        }

        /// <summary>
        /// Возвращает цену с округлением значения к ближайшему числу
        /// с учетом количества знаков после запятой для конкретной валюты
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public Price Round()
        {
            switch ( Currency )
            {
                case "RUB":
                case "EUR":
                case "USD":
                    return new Price( decimal.Round( Value, 2 ), Currency );
                default:
                    throw new InvalidOperationException( $"Unknown currency '{Currency}'" );
            }
        }

        public static Price operator +( Price left, Price right )
        {
            if ( left == null )
            {
                return right;
            }

            if ( right == null )
            {
                return left;
            }

            if ( left.Currency != right.Currency )
            {
                throw new ArgumentException(
                    $"Can't addition with \"{left.Currency}\" and \"{right.Currency}\" currencies" );
            }

            return new Price( left.Value + right.Value, left.Currency );
        }

        public static Price operator *( Price price, int denominator )
        {
            if ( denominator < 0 )
            {
                throw new ArgumentException();
            }

            return new Price( price.Value * denominator, price.Currency );
        }

        public static Price operator *( Price price, decimal denominator )
        {
            if ( denominator < 0 )
            {
                throw new ArgumentException();
            }

            return new Price( price.Value * denominator, price.Currency );
        }

        public static bool operator >( Price left, Price right )
        {
            ThrowIfCompareDifferentCurrencies( left, right );
            return left.Value > right.Value;
        }

        public static bool operator <( Price left, Price right )
        {
            ThrowIfCompareDifferentCurrencies( left, right );
            return left.Value < right.Value;
        }

        public static bool operator >=( Price left, Price right )
        {
            ThrowIfCompareDifferentCurrencies( left, right );
            return left.Value >= right.Value;
        }

        public static bool operator <=( Price left, Price right )
        {
            ThrowIfCompareDifferentCurrencies( left, right );
            return left.Value <= right.Value;
        }

        private static void ThrowIfCompareDifferentCurrencies( Price left, Price right )
        {
            if ( left.Currency != right.Currency )
            {
                throw new ArgumentException(
                    $"Can't compare with different currencies \"{left.Currency}\" and \"{right.Currency}\"" );
            }
        }

        public bool IsZero()
        {
            return Value == 0;
        }

        /// <summary>
        /// Неявное приведение возможно, так как область значений Price является подмножеством значений Amount
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        //public static implicit operator Amount(Price amount)
        //{
        //    return new Amount(amount.Value, amount.Currency);
        //}

        public Price Copy()
        {
            return new Price( Value, Currency );
        }

        protected Price()
        {
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
            yield return Currency;
        }

        public override string ToString()
        {
            return $"{Value.ToString( "0.00", System.Globalization.CultureInfo.InvariantCulture )} {Currency}";
        }
    }
}
