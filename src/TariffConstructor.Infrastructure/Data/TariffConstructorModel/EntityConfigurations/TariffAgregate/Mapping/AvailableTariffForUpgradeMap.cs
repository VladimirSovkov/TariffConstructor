using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TariffConstructor.Domain.TariffAggregate;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.TariffAgregate.Mapping
{
    public class AvailableTariffForUpgradeMap : IEntityTypeConfiguration<AvailableTariffForUpgrade>
    {
        public void Configure(EntityTypeBuilder<AvailableTariffForUpgrade> builder)
        {
            builder.ToTable("AvailableTariffForUpgrade");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseHiLo(HiLoSequence.DBSequenceHiLoForTariffAdvancePrice);
            
            builder.HasIndex(x => x.TenantId);
            
            builder.Property(x => x.ToTariffId).IsRequired();
            builder.Property(x => x.FromTariffId).IsRequired();
        }
    }
}
