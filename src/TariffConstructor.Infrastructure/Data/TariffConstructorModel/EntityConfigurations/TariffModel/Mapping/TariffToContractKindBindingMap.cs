using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TariffConstructor.Domain.TariffModel;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.TariffModel.Mapping
{
    public class TariffToContractKindBindingMap : IEntityTypeConfiguration<TariffToContractKindBinding>
    {
        public void Configure(EntityTypeBuilder<TariffToContractKindBinding> builder)
        {
            builder.ToTable("TariffToContractKindBinding");
            
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseHiLo(HiLoSequence.DBSequenceHiLoForTariffAdvancePrice);
            builder.HasOne(x => x.ContractKind).WithMany().HasForeignKey(x => x.ContractKindId);
        }
    }
}
