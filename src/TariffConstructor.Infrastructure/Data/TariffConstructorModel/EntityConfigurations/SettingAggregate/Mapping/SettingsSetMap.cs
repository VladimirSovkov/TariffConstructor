using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TariffConstructor.Domain.SettingModel;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.SettingAggregate.Mapping
{
    public class SettingsSetMap : IEntityTypeConfiguration<SettingsSet>
    {
        public void Configure(EntityTypeBuilder<SettingsSet> builder)
        {
            builder.ToTable("SettingsSet");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseHiLo(HiLoSequence.DBSequenceHiLoForSettingsSet);

            var billingSettingSetsNavigation =
                builder.Metadata.FindNavigation(nameof(SettingsSet.BillingSettingSets));
            billingSettingSetsNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            var applicationSettingSetsNavigation =
                builder.Metadata.FindNavigation(nameof(SettingsSet.ApplicationSettingSets));
            applicationSettingSetsNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
