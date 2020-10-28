
using Microsoft.EntityFrameworkCore;
using TariffConstructor.Domain.ObjectTests;
using TariffConstructor.Domain.ProductAggregate;
using TariffConstructor.Domain.TariffAggregate;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ObjectTests.Mapping;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ProductAggregateMap;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.TariffAgregate.Mapping;

namespace TariffConstructor.Infrastructure.Data
{
    public class TariffConstructorContext : DbContext
    {
        public TariffConstructorContext(DbContextOptions<TariffConstructorContext> options)
            : base (options)
        { 
        }

        public DbSet<IncludedProductInTariff> IncludedProductInTariff { get; set; }
        public DbSet<Product> Products { get; set; }
        //public DbSet<Tariff> Tariff { get; set; }
        public DbSet<TariffTestPeriod> TariffTestPeriods { get; set; }
        //сделано для тестов работы разных вариантов Fluent Api
        public DbSet<ClassWithEnum> classWithEnums { get; set; }

        protected override void OnModelCreating(ModelBuilder builder )
        {
            base.OnModelCreating(builder);

            //builder.Entity<IncludedProductInTariff>().ToTable("test", schema: "dbo");
            builder.ApplyConfiguration( new IncludedProductInTariffMap() );
            builder.ApplyConfiguration(new ProductMap());
            //builder.ApplyConfiguration(new TariffMap());
            builder.ApplyConfiguration(new TariffTestPeriodMap());
            builder.ApplyConfiguration(new ClassWithEnumMap());
        }
    }
}
