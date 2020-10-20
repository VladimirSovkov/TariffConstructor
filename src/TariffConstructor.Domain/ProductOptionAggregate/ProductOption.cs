using System;
using Billing.Services.Ordering.Domain.Marketing.ProductOptionKindAggregate;
using TariffConstructor.Toolkit.Aggregate;
using TariffConstructor.Domain.ProductAggregate;

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

        protected ProductOption()
        {
        }
    }
}
