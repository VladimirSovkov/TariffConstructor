﻿using System;
using TariffConstructor.Toolkit.Abstractions;
using TariffConstructor.Domain.ProductOptionKindAggregate;

namespace TariffConstructor.Domain.ProductAggregate
{
    public class Product : MultitenancyEntity, IAggregateRoot
    {
        public Product(
            string name,
            //ProductSettlementKinds productSettlementKinds,
            string publicId = null,
            string shortName = null )
        {
            Name = name;
            //ProductSettlementKinds = productSettlementKinds;
            ShortName = String.IsNullOrWhiteSpace( shortName ) ? name : shortName;
            PublicId = String.IsNullOrEmpty( publicId ) ? Guid.NewGuid().ToString() : publicId;
        }

        public string PublicId { get; private set; }

        public string NomenclatureId { get;  set; }

        public string Name { get; private set; }

        //в таблицу можно не выводить
        //нужно будет для изменения 
        public string ShortName { get; private set; }

        //public ProductSettlementKinds ProductSettlementKinds { get; private set; }

        public DateTime CreationDate { get; set; }

        public void SetNomenclatureId( string nomeclatureId )
        {
            NomenclatureId = nomeclatureId;
        }

        protected Product()
        {
        }
    }
}
