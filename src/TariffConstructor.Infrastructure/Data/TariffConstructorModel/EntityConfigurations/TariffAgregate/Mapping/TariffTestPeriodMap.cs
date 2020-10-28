using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TariffConstructor.Domain.TariffAggregate;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.TariffAgregate.Mapping
{
    public class TariffTestPeriodMap : IEntityTypeConfiguration<TariffTestPeriod>
    {
        public void Configure(EntityTypeBuilder<TariffTestPeriod> builder)
        {
            builder.ToTable("TariffTestPeriod");
            builder.HasNoKey();
        }
    }
}
