using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TariffConstructor.Domain.ApplicationSettingModel;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ApplicationSettingModel.Mapping
{
    public class ApplicationSettingValueMap : IEntityTypeConfiguration<ApplicationSettingValue>
    {
        public void Configure(EntityTypeBuilder<ApplicationSettingValue> builder)
        {
            builder.ToTable("ApplicationSettingValue");

            builder.HasKey(x => x.Id);
            builder.HasAlternateKey(x => new { x.ApplicationSettingId});
            builder.Property(x => x.Id).UseHiLo(HiLoSequence.DBSequenceHiLoForApplicationSettingValue);
            builder.Property(x => x.Value).HasMaxLength(100).IsRequired();
            builder.Property(x => x.CreationDate).ValueGeneratedOnAdd();
            builder.HasOne(x => x.ApplicationSetting).WithMany().HasForeignKey(x => x.ApplicationSettingId);
        }
    }
}
