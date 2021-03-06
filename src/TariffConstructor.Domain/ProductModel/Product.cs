﻿using System;
using TariffConstructor.Toolkit.Abstractions;
using TariffConstructor.Domain.ProductOptionKindModel;
using TariffConstructor.Domain.ValueObjects;

namespace TariffConstructor.Domain.ProductModel
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

        public string NomenclatureId { get; private set; }

        public string Name { get; private set; }

        public string ShortName { get; private set; }

        public ProductSettlementKinds ProductSettlementKinds { get; private set; }

        public DateTime CreationDate { get; private set; }

        public void SetPublicId(string publicId)
        {
            PublicId = publicId;
        }

        public void SetNomenclatureId( string nomeclatureId )
        {
            NomenclatureId = nomeclatureId;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetShortName(string shortName)
        {
            ShortName = shortName;
        }

        protected Product()
        {
        }
    }
}
