using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.Interface;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ObjectTests.Interface;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ObjectTests.Repository;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.TariffAgregate.Interface;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.TariffAgregate.Repository;

namespace TariffConstructor.Infrastructure.Data
{
    public static class DataBindings
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IIncludedProductInTariff, IncludedProductInTariffRepository>();
            services.AddScoped<IProduct, ProductRepository>();
            services.AddScoped<ITariffRepostitory, TariffRepository>();
            services.AddScoped<ITariffTestPeriod, TariffTestPeriodRepository>();
            services.AddScoped<IClassWithEnum, ClassWithEnumRepository>();
            return services;
        }

        public static IServiceCollection AddDatabase<T>(this IServiceCollection services, string connectionString)
            where T : DbContext
        {
            return services.AddDbContext<T>(c =>
            {
                try
                {
                    c.UseLazyLoadingProxies().UseSqlServer(connectionString);
                }
                catch (Exception)
                {
                    //TODO: logger
                }
            });
        }
    }
}
