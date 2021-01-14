using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TariffConstructor.Domain.TermsOfUseAggregate;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.TermsOfUseAggregate.Mapping
{
    public class TermsOfUseMap : IEntityTypeConfiguration<TermsOfUse>
    {
        public void Configure(EntityTypeBuilder<TermsOfUse> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseHiLo(HiLoSequence.DBSequenceHiLoForTermsOfUse);

            builder.HasAlternateKey(x => x.PublicId);

            builder.Property(x => x.DocumentName).HasMaxLength(255).IsRequired();
        }
    }
}
