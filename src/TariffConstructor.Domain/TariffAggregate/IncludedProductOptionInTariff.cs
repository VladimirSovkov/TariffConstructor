using System;
using TariffConstructor.Domain.Abstractions;
using TariffConstructor.Domain.ProductOptionAggregate;

namespace TariffConstructor.Domain.TariffAggregate
{
    public class IncludedProductOptionInTariff : Entity
    {
        public IncludedProductOptionInTariff(
            int productOptionId,
            int quantity )
        {
            ProductOptionId = productOptionId;
            Quantity = quantity;
        }

        public int Quantity { get; private set; }
        public int TariffId { get; private set; }
        public virtual Tariff Tariff { get; private set; }
        public int ProductOptionId { get; private set; }
        public virtual ProductOption ProductOption { get; private set; }
        public DateTime CreationDate { get; private set; }

        protected IncludedProductOptionInTariff()
        {
        }
    }
}
