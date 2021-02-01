using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TariffConstructor.Domain.ContractKindModel;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ContractKindModel.Map
{
    public class ContractKindMap : IEntityTypeConfiguration<ContractKind>
    {
        public void Configure(EntityTypeBuilder<ContractKind> builder)
        {
            builder.ToTable("ContractKind");

            builder.HasKey(x => x.Id);
            builder.HasIndex(b => b.PublicId)
                .IsUnique();
            builder.Property(x => x.Id).UseHiLo(HiLoSequence.DBSequenceHiLoForContractKind);
            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
            builder.Property(x => x.CreationDate).ValueGeneratedOnAdd();
        }
    }
}
