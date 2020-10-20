using System;
using TariffConstructor.Domain.Abstractions;
using TariffConstructor.Domain.ValueObjects;

namespace TariffConstructor.Domain.ProductOptionTariffAggregate
{
    public class ProductOptionTariffPrice : Entity
    {
        public ProductOptionTariffPrice(
            int productOptionTariffId,
            Price price,
            ProlongationPeriod period )
        {
            ProductOptionTariffId = productOptionTariffId;
            Price = price;
            Period = period;
        }

        public virtual Price Price { get; private set; }
        public virtual ProlongationPeriod Period { get; private set; }
        public DateTime CreationDate { get; private set; }

        public int ProductOptionTariffId { get; private set; }
        public virtual ProductOptionTariff ProductOptionTariff { get; private set; }

        protected ProductOptionTariffPrice()
        {
        }
    }
}
