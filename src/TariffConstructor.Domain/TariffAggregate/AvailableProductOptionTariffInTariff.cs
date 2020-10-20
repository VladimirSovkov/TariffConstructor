﻿using System;
using TariffConstructor.Domain.ProductOptionTariffAggregate;
using TariffConstructor.Toolkit.Aggregate;

namespace TariffConstructor.Domain.TariffAggregate
{
    public class AvailableProductOptionTariffInTariff : MultitenancyEntity, IAggregateRoot
    {
        public AvailableProductOptionTariffInTariff(
            int tariffId,
            int productOptionTariffId )
        {
            TariffId = tariffId;
            ProductOptionTariffId = productOptionTariffId;
        }

        public int TariffId { get; private set; }
        public int ProductOptionTariffId { get; private set; }
        public virtual ProductOptionTariff ProductOptionTariff { get; private set; }
        public int? MaxCount { get; private set; }
        public DateTime CreationDate { get; private set; }

        public void SetMaxCount( int count )
        {
            MaxCount = count;
        }

        protected AvailableProductOptionTariffInTariff()
        {
        }
    }
}
