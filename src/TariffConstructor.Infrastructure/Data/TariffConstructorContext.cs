
using Microsoft.EntityFrameworkCore;
using TariffConstructor.Domain.ProductAggregate;
using TariffConstructor.Domain.TariffAggregate;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ProductAggregateMap;

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

        protected override void OnModelCreating(ModelBuilder builder )
        {
            base.OnModelCreating(builder);

            builder.Entity<IncludedProductInTariff>().ToTable("test", schema: "dbo");
            builder.ApplyConfiguration( new IncludedProductInTariffMap() );
            builder.ApplyConfiguration(new ProductMap());
        }
    }
}
