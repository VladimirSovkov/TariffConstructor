using Microsoft.EntityFrameworkCore;
using TariffConstructor.Domain.ProductAggregate;
using TariffConstructor.Domain.ProductOptionAggregate;
using TariffConstructor.Domain.ProductOptionKindAggregate;
using TariffConstructor.Domain.ProductOptionTariffAggregate;
using TariffConstructor.Domain.TariffAggregate;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ProductAggregateMap;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ProductOptionAggregate.Mapping;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ProductOptionKindAggregate.Mapping;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ProductOptionTariffAggregate.Mapping;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.TariffAgregate.Mapping;

namespace TariffConstructor.Infrastructure.Data
{
    public class TariffConstructorContext : DbContext
    {
        public TariffConstructorContext(DbContextOptions<TariffConstructorContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        //public DbSet<TariffTestPeriod> TariffTestPeriods { get; set; }
        //сделано для тестов работы разных вариантов Fluent Api
        //public DbSet<ClassWithEnum> classWithEnums { get; set; }

        //ProductOptionAggregate
        public DbSet<ProductOption> ProductOptions { get; set; }

        //ProductOptionKindAggregate
        public DbSet<ProductOptionKind> ProductOptionKinds { get; set; }

        //ProductOptionTariffAggregate
        public DbSet<ProductOptionTariffPrice> ProductOptionTariffPrices { get; set; }
        public DbSet<ProductOptionTariff> ProductOptionTariffs { get; set; }

        //TariffAgregate
        public DbSet<IncludedProductInTariff> IncludedProductInTariff { get; set; }
        public DbSet<TariffPrice> TariffPrices { get; set; }
        public DbSet<Tariff> Tariffs { get; set; }
        public DbSet<AvailableProductOptionTariffInTariff> AvailableProductOptionTariffInTariffs { get; set; }


        protected override void OnModelCreating(ModelBuilder builder )
        {
            base.OnModelCreating(builder);
            
            builder.HasSequence<int>(HiLoSequence.DBSequenceHiLoForTariffAdvancePrice).StartsAt(1)
                .IncrementsBy(1);
            //TariffAgregate
            builder.ApplyConfiguration(new AvailableProductOptionTariffInTariffMap());
            builder.ApplyConfiguration(new TariffMap());
            builder.ApplyConfiguration(new TariffAdvancePriceMap());
            builder.ApplyConfiguration(new TariffPriceMap());
            builder.ApplyConfiguration(new IncludedProductInTariffMap());

            //ProductAggregate
            builder.ApplyConfiguration(new ProductMap());

            //ProductOptionKindAggregate
            builder.ApplyConfiguration(new ProductOptionKindMap());

            //ProductOptionAggregate
            builder.ApplyConfiguration(new ProductOptionMap());

            //ProductOptionTariffAggregate
            builder.ApplyConfiguration(new ProductOptionTariffPriceMap());
            builder.ApplyConfiguration(new ProductOptionTariffMap());



            //builder.Entity<IncludedProductInTariff>().ToTable("test", schema: "dbo");
            //builder.ApplyConfiguration(new TariffTestPeriodMap());
            //builder.ApplyConfiguration(new ClassWithEnumMap());
        }
    }
}
