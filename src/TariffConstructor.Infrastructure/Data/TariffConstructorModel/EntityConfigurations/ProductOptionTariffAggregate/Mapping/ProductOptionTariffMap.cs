using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TariffConstructor.Domain.ProductOptionTariffAggregate;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ProductOptionTariffAggregate.Mapping
{
    public class ProductOptionTariffMap : IEntityTypeConfiguration<ProductOptionTariff>
    {
        public void Configure(EntityTypeBuilder<ProductOptionTariff> builder)
        {
            builder.ToTable("ProductOptionTariff");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseHiLo(HiLoSequence.DBSequenceHiLoForTariffAdvancePrice);

            builder.HasIndex(x => x.TenantId);

            builder.Property(x => x.PublicId).HasMaxLength(100);
            builder.HasOne(x => x.ProductOption).WithMany().HasForeignKey(x => x.ProductOptionId);
            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
            builder.Property(x => x.CreationDate).ValueGeneratedOnAdd();

            var pricesNavigation = builder.Metadata.FindNavigation(nameof(ProductOptionTariff.Prices));
            pricesNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
