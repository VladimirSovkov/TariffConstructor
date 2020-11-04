using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TariffConstructor.Domain.ProductOptionKindAggregate;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ProductOptionKindAggregate.Mapping
{
    public class ProductOptionKindMap : IEntityTypeConfiguration<ProductOptionKind>
    {
        public void Configure(EntityTypeBuilder<ProductOptionKind> builder)
        {
            builder.ToTable("ProductOptionKind");

            builder.HasKey(x => x.Id);
            
            builder.HasIndex(x => x.TenantId);

            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
            builder.Property(x => x.PublicId).HasMaxLength(100);

            builder.Property(x => x.CreationDate).ValueGeneratedOnAdd();
        }
    }
}
