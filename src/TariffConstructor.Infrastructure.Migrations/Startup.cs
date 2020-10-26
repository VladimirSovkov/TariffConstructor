using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using TariffConstructor.Infrastructure.Data;

namespace TariffConstructor.Infrastructure.Migrations
{
    public class Startup : IStartup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            Console.WriteLine(
                $"Migration run as user: \"{System.Security.Principal.WindowsIdentity.GetCurrent().Name}\"");

            Console.WriteLine(
                $"Migration connection string: \"{_configuration.GetConnectionString("TariffConstructorConnection")}\"");

            services.AddDbContext<TariffConstructorContext>(x =>
                x.UseSqlServer(_configuration.GetConnectionString("TariffConstructorConnection")));

            return services.BuildServiceProvider();
        }

        public virtual void Configure(IApplicationBuilder app)
        {
            InitializeDatabase(app);
        }

        private void InitializeDatabase(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var contextFactory = new DesignTimeRepositoryContextFactory();
                TariffConstructorContext context = contextFactory.CreateDbContext(new string[] { });
                context.Database.Migrate();

                string[] appliedMigrations = context.Database.GetAppliedMigrations().ToArray();
                Console.WriteLine(String.Join("\n", appliedMigrations));
            }
        }
    }
}