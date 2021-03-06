﻿using System;
using TariffConstructor.Toolkit.Abstractions;

namespace TariffConstructor.Domain.ProductOptionKindModel
{
    public class ProductOptionKind : MultitenancyEntity, IAggregateRoot
    {
        public ProductOptionKind(
            string name,
            string publicId = null )
        {
            Name = name;
            PublicId = String.IsNullOrEmpty( publicId ) ? Guid.NewGuid().ToString() : publicId;
        }

        public string PublicId { get; private set; }
        public string Name { get; private set; }
        public DateTime CreationDate { get; private set; }

        protected ProductOptionKind()
        {
        }
    }
}
