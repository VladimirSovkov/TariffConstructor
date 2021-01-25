using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TariffConstructor.Domain.ApplicationSettingModel;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ApplicationSettingModel.Mapping
{
    public class ApplicationSettingMap : IEntityTypeConfiguration<ApplicationSetting>
    {
        public void Configure(EntityTypeBuilder<ApplicationSetting> builder)
        {
            builder.ToTable("ApplicationSetting");

            builder.HasKey(x => x.Id);
            builder.HasAlternateKey(x => new { x.ApplicationId, x.SettingId });

            builder.Property(x => x.Id).UseHiLo(HiLoSequence.DBSequenceHiLoForApplicationSetting);
            builder.Property(x => x.DefaultValue).HasMaxLength(50);

            builder.Property(x => x.CreationDate).ValueGeneratedOnAdd();
            builder.Property(x => x.PublicId).HasMaxLength(68);

            builder.HasOne(x => x.Application).WithMany().HasForeignKey(x => x.ApplicationId);
            builder.HasOne(x => x.Setting).WithMany().HasForeignKey(x => x.SettingId);

            var navigation = builder.Metadata.FindNavigation(nameof(ApplicationSetting.SettingValues));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
