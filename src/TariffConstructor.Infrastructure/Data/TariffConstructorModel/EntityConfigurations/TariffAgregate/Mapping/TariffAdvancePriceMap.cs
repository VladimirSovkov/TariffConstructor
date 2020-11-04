using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TariffConstructor.Domain.TariffAggregate;
using TariffConstructor.Infrastructure.Data;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.TariffAgregate.Mapping
{
    public class TariffAdvancePriceMap : IEntityTypeConfiguration<TariffAdvancePrice>
    {
        public void Configure(EntityTypeBuilder<TariffAdvancePrice> builder)
        {
            builder.ToTable("TariffAdvancePrice");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseHiLo(HiLoSequence.DBSequenceHiLoForTariffAdvancePrice);

            builder.Property(x => x.CreationDate).ValueGeneratedOnAdd();
            
            builder.OwnsOne(x => x.Price, y => y.Property(p => p.Currency).HasMaxLength(3));
            builder.OwnsOne(x => x.Period);

            builder.HasOne(x => x.Tariff).WithMany(x => x.AdvancePrices).HasForeignKey(x => x.TariffId);

            //builder.Ignore(x => x.DomainEvents);
        }
    }
}
