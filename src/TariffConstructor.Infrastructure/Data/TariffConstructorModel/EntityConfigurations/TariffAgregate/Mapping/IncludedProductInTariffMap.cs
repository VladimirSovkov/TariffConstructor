using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TariffConstructor.Domain.TariffModel;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations
{
    class IncludedProductInTariffMap : IEntityTypeConfiguration<IncludedProductInTariff>
    {
        public void Configure(EntityTypeBuilder<IncludedProductInTariff> builder)
        {
            builder.ToTable("IncludedProductInTariff");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseHiLo(HiLoSequence.DBSequenceHiLoForTariffAdvancePrice);

            builder.HasOne(x => x.Tariff).WithMany(x => x.IncludedProducts).HasForeignKey(x => x.TariffId);
            builder.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.ProductId);

            builder.Property(x => x.RelativeWeight).IsRequired();

            //builder.Ignore(x => x.DomainEvents);
        }
    }
}
