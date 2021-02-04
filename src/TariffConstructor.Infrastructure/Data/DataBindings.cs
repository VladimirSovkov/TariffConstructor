using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using TariffConstructor.Domain.TariffModel;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.TariffModel.Repository;
using TariffConstructor.Domain.ProductModel;
using TariffConstructor.Domain.ProductOptionModel;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ProductOptionModel.Repository;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.SettingModel.Repository;
using TariffConstructor.Domain.SettingModel;
using TariffConstructor.Domain.ApplicationSettingModel;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ApplicationSettingModel.Repository;
using TariffConstructor.Domain.BillingSettingModel;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.BillingSettingModel.Repository;
using TariffConstructor.Domain.TermsOfUseModel;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.TermsOfUseModel.Repository;
using TariffConstructor.Domain.ApplicationModel;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ApplicationModel.Repository;
using TariffConstructor.Domain.CurrencyModel;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.CurrencyModel.Repository;
using TariffConstructor.Domain.ProductOptionTariffModel;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ProductOptionTariffModel.Repository;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ProductModel.Repository;
using TariffConstructor.Domain.ContractKindModel;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ContractKindModel.Repository;

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
            services.AddScoped<ICurrencyRepository, CurrencyRepository>();
            services.AddScoped<IProductOptionTariffRepository, ProductOptionTariffRepository>();
            services.AddScoped<IContractKindRepository, ContractKindRepository>();
            services.AddScoped<IAvailableTariffForUpgradeRepository, AvailableTariffForUpgradeRepository>();
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
