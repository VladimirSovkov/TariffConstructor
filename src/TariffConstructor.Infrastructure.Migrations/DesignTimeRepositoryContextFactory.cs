using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using TariffConstructor.Infrastructure.Data;


namespace TariffConstructor.Infrastructure.Migrations
{
    public class DesignTimeRepositoryContextFactory : IDesignTimeDbContextFactory<TariffConstructorContext>
    {
        public TariffConstructorContext CreateDbContext(string[] args)
        {
            IConfiguration config = MigrationExtension.GetConfig();
            var connectionString = config.GetConnectionString("TariffConstructorConnection");
            var optionsBuilder = new DbContextOptionsBuilder<TariffConstructorContext>();
            optionsBuilder.UseSqlServer(connectionString,
                x => x.MigrationsAssembly("TariffConstructor.Infrastructure.Migrations"));
            return new TariffConstructorContext(optionsBuilder.Options);
        }
    }
}