using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TariffConstructor.Domain.ObjectTests;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ObjectTests.Mapping
{
    public class ClassWithEnumMap : IEntityTypeConfiguration<ClassWithEnum>
    {
        public void Configure(EntityTypeBuilder<ClassWithEnum> builder)
        {
            builder.ToTable("ClassWithEnum");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Value).HasMaxLength(40);

            //builder.Property(x => x.Time).HasConversion<int>();
            //builder.Property(x => x.Time).HasDefaultValue(TimesOfDay.day);
            
        }
    }
}
