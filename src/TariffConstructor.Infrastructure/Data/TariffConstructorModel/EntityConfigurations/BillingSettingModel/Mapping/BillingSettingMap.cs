using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TariffConstructor.Domain.BillingSettingModel;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.BillingSettingModel.Mapping
{
    public class BillingSettingMap : IEntityTypeConfiguration<BillingSetting>
    {
        public void Configure(EntityTypeBuilder<BillingSetting> builder)
        {
            builder.ToTable("BillingSetting");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseHiLo(HiLoSequence.DBSequenceHiLoForBillingSetting);
            builder.HasAlternateKey(x => new { x.SettingId, x.PublicId });

            builder.HasOne(x => x.Setting).WithMany().HasForeignKey(x => x.SettingId);
        }
    }
}
