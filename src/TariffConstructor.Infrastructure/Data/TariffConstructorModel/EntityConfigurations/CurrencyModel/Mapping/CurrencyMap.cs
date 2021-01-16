using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TariffConstructor.Domain.CurrencyModel;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.CurrencyModel.Mapping
{
    public class CurrencyMap : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.ToTable("Currency");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseHiLo(HiLoSequence.DBSequenceHiLoForCurrency);
            builder.Property(x => x.Name).HasMaxLength(3);
            builder.HasAlternateKey(x => new { x.Code, x.Name });
        }
    }
}
