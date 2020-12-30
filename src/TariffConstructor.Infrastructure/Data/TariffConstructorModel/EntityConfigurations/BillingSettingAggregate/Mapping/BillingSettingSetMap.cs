using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TariffConstructor.Domain.BillingSettingAggregate;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.BillingSettingAggregate.Mapping
{
    public class BillingSettingSetMap : IEntityTypeConfiguration<BillingSettingSet>
    {
        public void Configure(EntityTypeBuilder<BillingSettingSet> builder)
        {
            builder.ToTable("BillingSettingSet");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseHiLo(HiLoSequence.DBSequenceHiLoForBillingSettingSet);

            builder.HasAlternateKey(x => new { x.SettingsSetId, x.BillingSettingId });
            builder.Property(x => x.SettingsSetId).IsRequired();
            builder.Property(x => x.Value).HasMaxLength(150);

            builder.HasOne(x => x.BillingSetting).WithMany().HasForeignKey(x => x.BillingSettingId);
        }
    }
}
