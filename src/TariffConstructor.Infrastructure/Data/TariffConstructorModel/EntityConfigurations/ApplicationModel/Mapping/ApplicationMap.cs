using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TariffConstructor.Domain.ApplicationModel;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ApplicationModel.Mapping
{
    public class ApplicationMap : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.ToTable("Application");

            builder.HasKey(x => x.Id);
            builder.HasIndex(b => b.PublicId).IsUnique();
            builder.Property(x => x.Id).UseHiLo(HiLoSequence.DBSequenceHiLoForApplication);
            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
        }
    }
}
