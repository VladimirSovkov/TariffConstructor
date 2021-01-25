using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TariffConstructor.Domain.ApplicationSettingModel;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ApplicationSettingModel.Mapping
{
    public class ApplicationSettingSetMap : IEntityTypeConfiguration<ApplicationSettingSet>
    {
        public void Configure(EntityTypeBuilder<ApplicationSettingSet> builder)
        {
            builder.ToTable("ApplicationSettingSet");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseHiLo(HiLoSequence.DBSequenceHiLoForApplicationSettingSet);
            builder.HasAlternateKey(x => new { x.ApplicationSettingId, x.SettingsSetId });

            builder.HasOne(x => x.ApplicationSetting).WithMany().HasForeignKey(x => x.ApplicationSettingId);

            builder.Property(x => x.Value);
        }
    }
}
