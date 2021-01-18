using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TariffConstructor.Domain.TariffModel;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.TariffAgregate.Mapping
{
    public class AvailableProductOptionTariffInTariffMap : IEntityTypeConfiguration<AvailableProductOptionTariffInTariff>
    {
        public void Configure(EntityTypeBuilder<AvailableProductOptionTariffInTariff> builder)
        {
            builder.ToTable("AvailableProductOptionTariffInTariff");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseHiLo(HiLoSequence.DBSequenceHiLoForTariffAdvancePrice);

            builder.HasIndex(x => x.TenantId);

            builder.Property(x => x.TariffId).IsRequired();

            builder.HasOne(x => x.ProductOptionTariff).WithMany().HasForeignKey(x => x.ProductOptionTariffId);

            builder.Property(x => x.CreationDate).ValueGeneratedOnAdd();
        }
    }
}
