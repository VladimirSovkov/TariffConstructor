﻿using System;
using TariffConstructor.Domain.ValueObjects;
using TariffConstructor.Toolkit.Abstractions;

namespace TariffConstructor.Domain.ProductOptionTariffModel
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

        public void SetPrice(Price price)
        {
            Price = price;
        }

        public void SetPeriod(ProlongationPeriod period)
        {
            Period = period;
        }

        protected ProductOptionTariffPrice()
        {
        }
    }
}
