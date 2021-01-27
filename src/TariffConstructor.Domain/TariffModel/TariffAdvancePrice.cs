using System;
using TariffConstructor.Domain.ValueObjects;
using TariffConstructor.Toolkit.Abstractions;

namespace TariffConstructor.Domain.TariffModel
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

        public void SetPrice(Price price)
        {
            Price = price;
        }

        public void SetPeriod(ProlongationPeriod period)
        {
            Period = period;
        }

        protected TariffAdvancePrice()
        {
        }
    }
}
