using System;
using TariffConstructor.Domain.ProductOptionModel;
using TariffConstructor.Toolkit.Abstractions;

namespace TariffConstructor.Domain.TariffModel
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

        public void SetQuantity(int quantity)
        {
            Quantity = quantity;
        }

        public void SetProductOptionId(int productOptionId)
        {
            if (ProductOptionId != productOptionId)
            {
                ProductOptionId = productOptionId;
            }
        }


        protected IncludedProductOptionInTariff()
        {
        }
    }
}
