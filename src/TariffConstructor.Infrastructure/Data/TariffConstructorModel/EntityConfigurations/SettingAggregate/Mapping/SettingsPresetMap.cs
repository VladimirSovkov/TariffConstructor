using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TariffConstructor.Domain.SettingAggregate;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.SettingAggregate.Mapping
{
    public class SettingsPresetMap : IEntityTypeConfiguration<SettingsPreset>
    {
        public void Configure(EntityTypeBuilder<SettingsPreset> builder)
        {
            builder.ToTable("SettingsPreset");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseHiLo(HiLoSequence.DBSequenceHiLoForSettingsPreset);

            builder.Property(x => x.Name).HasMaxLength(255);

            var billingSettingPresetsNavigation =
                builder.Metadata.FindNavigation(nameof(SettingsPreset.BillingSettingPresets));
            billingSettingPresetsNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            var applicationSettingPresetsNavigation =
                builder.Metadata.FindNavigation(nameof(SettingsPreset.ApplicationSettingPresets));
            applicationSettingPresetsNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
