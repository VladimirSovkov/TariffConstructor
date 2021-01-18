using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TariffConstructor.Domain.ProductModel;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ProductAggregateMap
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(x => x.Id);
            builder.HasAlternateKey(x => x.PublicId);
            builder.HasIndex(x => x.TenantId);

            builder.Property(x => x.Id).UseHiLo(HiLoSequence.DBSequenceHiLoForTariffAdvancePrice);

            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
            
            builder.Property(x => x.PublicId).HasMaxLength(68);
            builder.Property(x => x.NomenclatureId).HasMaxLength(50);
            builder.Property(x => x.ShortName).HasMaxLength(100);

            builder.Property(x => x.CreationDate).ValueGeneratedOnAdd();

            //builder.Ignore(x => x.DomainEvents);
        }
    }
}
