using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TariffConstructor.Domain.SettingModel;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.SettingModel.Mapping
{
    public class SettingEnumValueMap : IEntityTypeConfiguration<SettingEnumValue>

    {
        public void Configure(EntityTypeBuilder<SettingEnumValue> builder)
        {
            builder.ToTable("SettingEnumValue");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseHiLo(HiLoSequence.DBSequenceHiLoForSettingEnumValue);

            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Code).HasMaxLength(100).IsRequired();
        }
    }
}
