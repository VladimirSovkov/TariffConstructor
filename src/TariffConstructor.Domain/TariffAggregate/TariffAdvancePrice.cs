using System;
using TariffConstructor.Domain.Abstractions;
using TariffConstructor.Domain.ValueObjects;

namespace TariffConstructor.Domain.TariffAggregate
{
    public class TariffAdvancePrice : Entity
    {
        public TariffAdvancePrice(
            Price price,
            ProlongationPeriod period )
        {
            if ( price == null || price.Value <= 0)
            {
                throw new ArgumentException( "The price cannot be null and must be greater than zero." );
            }

            Price = new Price( price.Value, price.Currency );
            Period = new ProlongationPeriod( period.Value, period.Unit );
        }

        public virtual Price Price { get; private set; }
        public virtual ProlongationPeriod Period { get; private set; }

        public DateTime CreationDate { get; private set; }

        public int TariffId { get; private set; }
        public virtual Tariff Tariff { get; private set; }

        protected TariffAdvancePrice()
        {
        }
    }
}
