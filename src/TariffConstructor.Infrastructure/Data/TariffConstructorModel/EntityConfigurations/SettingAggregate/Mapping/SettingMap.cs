using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TariffConstructor.Domain.SettingAggregate;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.SettingAggregate.Mapping
{
    public class SettingMap : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.ToTable("Setting");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseHiLo(HiLoSequence.DBSequenceHiLoForSetting);

            builder.Property(x => x.Code).HasMaxLength(50);
            builder.Property(x => x.Name).HasMaxLength(255);

            builder.Property(x => x.CreationDate).ValueGeneratedOnAdd();

            var navigation = builder.Metadata.FindNavigation(nameof(Setting.EnumValues));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
