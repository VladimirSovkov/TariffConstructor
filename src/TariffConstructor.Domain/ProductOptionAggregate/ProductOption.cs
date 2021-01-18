using System;
using TariffConstructor.Domain.ProductAggregate;
using TariffConstructor.Domain.ProductOptionKindAggregate;
using TariffConstructor.Toolkit.Abstractions;

namespace TariffConstructor.Domain.ProductOptionAggregate
{
    public class ProductOption : MultitenancyEntity, IAggregateRoot
    {
        public ProductOption(
            int productId,
            string name,
            bool isMultiple,
            string publicId = null )
        {
            ProductId = productId;
            Name = name;
            IsMultiple = isMultiple;
            PublicId = String.IsNullOrEmpty( publicId ) ? Guid.NewGuid().ToString() : publicId;
            AccountingName = string.Empty;
        }

        public string PublicId { get; private set; }
        public string NomenclatureId { get; private set; }
        public string Name { get; private set; }
        public bool IsMultiple { get; private set; }
        public int ProductId { get; private set; }
        public virtual Product Product { get; private set; }
        public int? KindId { get; private set; }
        public virtual ProductOptionKind Kind { get; private set; }
        public DateTime CreationDate { get; private set; }  
        public string AccountingName { get; private set; }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetNomenclatureId(string nomenclatureId)
        {
            NomenclatureId = nomenclatureId;
        }

        public void SetKindId(int? kindId)
        {
            KindId = kindId;
        }

        public void SetIsMultiple(bool isMultiple)
        {
            IsMultiple = isMultiple;
        }

        public void SetProductId(int productId)
        {
            if (productId != ProductId)
            {
                ProductId = productId;
            }
        }

        public void SetAccountingName(string accountingName)
        {
            AccountingName = accountingName;
        }

        protected ProductOption()
        {
        }
    }
}
