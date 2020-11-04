using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TariffConstructor.Domain.TariffAggregate;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.TariffAgregate.Mapping
{
    public class TariffPriceMap : IEntityTypeConfiguration<TariffPrice>
    {
        public void Configure(EntityTypeBuilder<TariffPrice> builder)
        {
            builder.ToTable("TariffPrice");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseHiLo(HiLoSequence.DBSequenceHiLoForTariffAdvancePrice);

            builder.Property(x => x.CreationDate).ValueGeneratedOnAdd();
            builder.OwnsOne(x => x.Price, y => y.Property(p => p.Currency).HasMaxLength(3));
            builder.OwnsOne(x => x.Period);

            builder.HasOne(x => x.Tariff).WithMany(x => x.Prices).HasForeignKey(x => x.TariffId);

            //builder.Ignore(x => x.DomainEvents);
        }
    }
}
