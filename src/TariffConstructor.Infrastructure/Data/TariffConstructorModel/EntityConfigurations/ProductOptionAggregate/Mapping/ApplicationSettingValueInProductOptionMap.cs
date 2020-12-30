using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TariffConstructor.Domain.ProductOptionAggregate;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ProductOptionAggregate.Mapping
{
    public class ApplicationSettingValueInProductOptionMap : IEntityTypeConfiguration<ApplicationSettingValueInProductOption>
    {
        public void Configure(EntityTypeBuilder<ApplicationSettingValueInProductOption> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .UseHiLo(HiLoSequence.DBSequenceHiLoForApplicationSettingValueInProductOption);

            builder.HasOne(x => x.ApplicationSettingValue)
                .WithMany()
                .HasForeignKey(x => x.ApplicationSettingValueId);
        }
    }
}
