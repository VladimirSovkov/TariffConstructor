using System;
using TariffConstructor.Domain.ValueObjects;
using TariffConstructor.Toolkit.Abstractions;

namespace TariffConstructor.Domain.TariffAggregate
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
        //public virtual Tariff Tariff { get; private set; }

        protected TariffPrice()
        {
        }
    }
}
