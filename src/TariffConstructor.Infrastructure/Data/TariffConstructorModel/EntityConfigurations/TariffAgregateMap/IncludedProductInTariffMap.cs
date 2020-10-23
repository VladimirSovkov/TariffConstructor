using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TariffConstructor.Domain.TariffAggregate;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations
{
    class IncludedProductInTariffMap : IEntityTypeConfiguration<IncludedProductInTariff>
    {
        public void Configure(EntityTypeBuilder<IncludedProductInTariff> builder)
        {
            builder.HasKey(x => x.TariffId);

        }
    }
}
