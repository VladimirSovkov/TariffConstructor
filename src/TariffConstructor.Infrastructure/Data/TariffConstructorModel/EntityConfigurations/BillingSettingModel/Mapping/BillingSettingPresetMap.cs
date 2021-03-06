﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TariffConstructor.Domain.BillingSettingModel;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.BillingSettingModel.Mapping
{
    public class BillingSettingPresetMap : IEntityTypeConfiguration<BillingSettingPreset>
    {
        public void Configure(EntityTypeBuilder<BillingSettingPreset> builder)
        {
            builder.ToTable("BillingSettingPreset");

            builder.HasKey(x => x.Id);
            builder.HasAlternateKey(x => new { x.BillingSettingId, x.SettingsPresetId });
            builder.Property(x => x.Id)
                .UseHiLo(HiLoSequence.DBSequenceHiLoForBillingSettingPreset);

            builder.HasOne(x => x.BillingSetting).WithMany().HasForeignKey(x => x.BillingSettingId);

            builder.OwnsOne(x => x.Value, x =>
            {
                x.Property(y => y.DefaultValue);
                x.Property(y => y.MinValue);
                x.Property(y => y.MaxValue);
            });
        }
    }
}
