using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TariffConstructor.Domain.TariffAggregate;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations
{
    class IncludedProductInTariffMap : IEntityTypeConfiguration<IncludedProductInTariff>
    {
        public void Configure(EntityTypeBuilder<IncludedProductInTariff> builder)
        {
            builder.HasKey(x => x.Id);

            //builder.Ignore(x => x.DomainEvents);
            //builder.Property(x => x.Id)
            //    .ForSqlServerUseSequenceHiLo(HiLoSequence.DBSequenceHiLoForIncludedProductInTariff);
            //

            //builder.HasOne(x => x.Tariff).WithMany(x => x.IncludedProducts).HasForeignKey(x => x.TariffId);
            builder.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.ProductId);
        }
    }
}
