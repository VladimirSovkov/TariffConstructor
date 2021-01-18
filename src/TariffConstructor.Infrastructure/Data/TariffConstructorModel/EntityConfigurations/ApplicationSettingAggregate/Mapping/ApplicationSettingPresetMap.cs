using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TariffConstructor.Domain.ApplicationSettingModel;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ApplicationSettingAggregate.Mapping
{
    public class ApplicationSettingPresetMap : IEntityTypeConfiguration<ApplicationSettingPreset>
    {
        public void Configure(EntityTypeBuilder<ApplicationSettingPreset> builder)
        {
            builder.ToTable("ApplicationSettingPreset");

            builder.HasKey(x => x.Id);
            builder.HasAlternateKey(x => new { x.ApplicationSettingId, x.SettingsPresetId });

            builder.Property(x => x.Id)
                .UseHiLo(HiLoSequence.DBSequenceHiLoForApplicationSettingPreset);

            builder.OwnsOne(x => x.Value, x =>
            {
                x.Property(y => y.DefaultValue);
                x.Property(y => y.MinValue);
                x.Property(y => y.MaxValue);
            });

            builder.HasOne(x => x.ApplicationSetting).WithMany().HasForeignKey(x => x.ApplicationSettingId);
        }
    }
}
