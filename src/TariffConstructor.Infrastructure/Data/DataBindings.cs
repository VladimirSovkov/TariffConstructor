using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using TariffConstructor.Domain.TariffAggregate;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.TariffAgregate.Repository;
using TariffConstructor.Domain.ProductAggregate;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations;
using TariffConstructor.Domain.ProductOptionAggregate;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ProductOptionAggregate.Repository;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.SettingAggregate.Repository;
using TariffConstructor.Domain.SettingAggregate;
using TariffConstructor.Domain.ApplicationSettingAggregate;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ApplicationSettingAggregate.Repository;
using TariffConstructor.Domain.BillingSettingAggregate;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.BillingSettingAggregate.Repository;
using TariffConstructor.Domain.TermsOfUseAggregate;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.TermsOfUseAggregate.Repository;
using TariffConstructor.Domain.ApplicationModel;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ApplicationModel.Repository;

namespace TariffConstructor.Infrastructure.Data
{
    public static class DataBindings
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITariffRepository, TariffRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductOptionRepository, ProductOptionRepository>();
            services.AddScoped<ISettingRepository, SettingRepository>();
            services.AddScoped<IApplicationSettingRepository, ApplicationSettingRepository>();
            services.AddScoped<IBillingSettingRepository, BillingSettingRepository>();
            services.AddScoped<ISettingsPresetRepository, SettingsPresetRepository>();
            services.AddScoped<ITermsOfUseRepository, TermsOfUseRepository>();
            services.AddScoped<IApplicationRepository, ApplicationRepository>();
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
