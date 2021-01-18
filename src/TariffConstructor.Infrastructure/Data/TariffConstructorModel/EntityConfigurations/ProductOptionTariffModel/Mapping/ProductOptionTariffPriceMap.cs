using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TariffConstructor.Domain.ProductOptionTariffModel;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ProductOptionTariffModel.Mapping
{
    public class ProductOptionTariffPriceMap : IEntityTypeConfiguration<ProductOptionTariffPrice>
    {
        public void Configure(EntityTypeBuilder<ProductOptionTariffPrice> builder)
        {
            builder.ToTable("ProductOptionTariffPrice");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseHiLo(HiLoSequence.DBSequenceHiLoForProductOptionTariffPrice);
            
            builder.OwnsOne(x => x.Price, y => y.Property(p => p.Currency).HasMaxLength(3));
            builder.OwnsOne(x => x.Period);

            builder.HasOne(x => x.ProductOptionTariff).WithMany(x => x.Prices).HasForeignKey(x => x.ProductOptionTariffId);

            builder.Property(x => x.CreationDate).ValueGeneratedOnAdd();
        }
    }
}
