using TariffConstructor.Domain.TariffAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations
{
    public class TariffMap : IEntityTypeConfiguration<Tariff>
    {
        public void Configure(EntityTypeBuilder<Tariff> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.TenantId);

            var pricesNavigation = builder.Metadata.FindNavigation(nameof(Tariff.Prices));
            pricesNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            var tariffAdvancePriecesNavigation = builder.Metadata.FindNavigation(nameof(Tariff.AdvancePrices));
            tariffAdvancePriecesNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            var includedProductOptions = builder.Metadata.FindNavigation(nameof(Tariff.IncludedProductOptions));
            includedProductOptions.SetPropertyAccessMode(PropertyAccessMode.Field);

            var contractKindBindings = builder.Metadata.FindNavigation(nameof(Tariff.ContractKindBindings));
            contractKindBindings.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();

            builder.Property(x => x.CreationDate).ValueGeneratedOnAdd();
            builder.OwnsOne(x => x.TestPeriod, y => y.Property(z => z.Unit).IsRequired());
            
            builder.HasAlternateKey(x => x.PublicId);
            
            builder.Property(x => x.AccountingName).HasMaxLength(100);
            builder.Property(x => x.AwaitingPaymentStrategy).HasMaxLength(100);
            builder.Property(x => x.AccountingTariffId).HasMaxLength(100);
        }
    }
}
