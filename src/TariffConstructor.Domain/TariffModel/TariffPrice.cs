using System;
using TariffConstructor.Domain.ValueObjects;
using TariffConstructor.Toolkit.Abstractions;

namespace TariffConstructor.Domain.TariffModel
{
    public class TariffPrice : Entity
    {
        public TariffPrice(
            Price price,
            ProlongationPeriod period )
        {
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

        protected TariffPrice()
        {
        }
    }
}
