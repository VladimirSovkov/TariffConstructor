using TariffConstructor.Domain.TariffAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TariffConstructor.Domain.ValueObjects;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations
{
    public class TariffMap : IEntityTypeConfiguration<Tariff>
    {
        public void Configure(EntityTypeBuilder<Tariff> builder)
        {
            builder.ToTable("Tariff");
            builder.HasKey(x => x.Id);

            builder.Ignore(x => x.Prices);
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.HasAlternateKey(x => x.PublicId);
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.AccountingName).HasMaxLength(100);
            builder.Property(x => x.AwaitingPaymentStrategy).HasMaxLength(100);
            builder.Property(x => x.AccountingTariffId).HasMaxLength(100);
        }
    }
}
