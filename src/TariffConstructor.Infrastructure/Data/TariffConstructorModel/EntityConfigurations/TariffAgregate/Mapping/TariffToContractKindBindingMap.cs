using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography.X509Certificates;
using TariffConstructor.Domain.TariffAggregate;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.TariffAgregate.Mapping
{
    public class TariffToContractKindBindingMap : IEntityTypeConfiguration<TariffToContractKindBinding>
    {
        public void Configure(EntityTypeBuilder<TariffToContractKindBinding> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ContractKindId).IsRequired();
        }
    }
}
