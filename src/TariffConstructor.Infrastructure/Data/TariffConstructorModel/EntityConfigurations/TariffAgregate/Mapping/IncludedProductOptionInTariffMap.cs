using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TariffConstructor.Domain.TariffModel;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.TariffAgregate.Mapping
{
    public class IncludedProductOptionInTariffMap : IEntityTypeConfiguration<IncludedProductOptionInTariff>
    {
        public void Configure(EntityTypeBuilder<IncludedProductOptionInTariff> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseHiLo(HiLoSequence.DBSequenceHiLoForTariffAdvancePrice);

            builder.Property(x => x.Quantity).IsRequired();

            builder.HasOne(x => x.Tariff).WithMany(x => x.IncludedProductOptions).HasForeignKey(x => x.TariffId);
            builder.HasOne(x => x.ProductOption).WithMany().HasForeignKey(x => x.ProductOptionId);

            builder.Property(x => x.CreationDate).ValueGeneratedOnAdd();

            //builder.Ignore(x => x.DomainEvents);
        }
    }
}
