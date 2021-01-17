using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Linq;
using TariffConstructor.Domain.ApplicationModel;
using TariffConstructor.Domain.ApplicationSettingAggregate;
using TariffConstructor.Domain.BillingSettingAggregate;
using TariffConstructor.Domain.CurrencyModel;
using TariffConstructor.Domain.ProductAggregate;
using TariffConstructor.Domain.ProductOptionAggregate;
using TariffConstructor.Domain.ProductOptionKindAggregate;
using TariffConstructor.Domain.ProductOptionTariffAggregate;
using TariffConstructor.Domain.SettingAggregate;
using TariffConstructor.Domain.TariffAggregate;
using TariffConstructor.Domain.TermsOfUseAggregate;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ApplicationModel.Mapping;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ApplicationSettingAggregate.Mapping;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.BillingSettingAggregate.Mapping;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.CurrencyModel.Mapping;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ProductAggregateMap;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ProductOptionAggregate.Mapping;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ProductOptionKindAggregate.Mapping;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ProductOptionTariffAggregate.Mapping;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ProductOptionTariffModel.Mapping;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.SettingAggregate.Mapping;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.TariffAgregate.Mapping;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.TermsOfUseAggregate.Mapping;

namespace TariffConstructor.Infrastructure.Data
{
    public class TariffConstructorContext : DbContext
    {
        public TariffConstructorContext(DbContextOptions<TariffConstructorContext> options)
            : base(options)
        {
        }

        //Application
        public DbSet<Application> Applications { get; set; }

        //ApplicationSettingAggregate
        public DbSet<ApplicationSettingSet> ApplicationSettingSets { get; set; }
        public DbSet<ApplicationSettingValue> ApplicationSettingValues { get; set; }
        public DbSet<ApplicationSetting> ApplicationSettings { get; set; }
        public DbSet<ApplicationSettingPreset> ApplicationSettingPresets { get; set; }

        //BillingSettingAggregate
        public DbSet<BillingSetting> BillingSettings { get; set; }
        public DbSet<BillingSettingSet> BillingSettingSets { get; set; }
        public DbSet<BillingSettingPreset> BillingSettingPresets { get; set; }

        //CurrencyModel
        public DbSet<Currency> Currencies{ get; set; }

        //ProductAggregate
        public DbSet<Product> Products { get; set; }

        //ProductOptionAggregate
        public DbSet<ProductOption> ProductOptions { get; set; }

        //ProductOptionKindAggregate
        public DbSet<ProductOptionKind> ProductOptionKinds { get; set; }

        //ProductOptionTariffAggregate
        public DbSet<ProductOptionTariffPrice> ProductOptionTariffPrices { get; set; }
        public DbSet<ProductOptionTariff> ProductOptionTariffs { get; set; }

        //SettingAggregate
        public DbSet<Setting> Settings { get; set; }
        public DbSet<SettingEnumValue> SettingEnumValues { get; set; }
        public DbSet<SettingsSet> SettingsSets { get; set; }
        public DbSet<SettingsPreset> SettingsPresets { get; set; }



        //TariffAgregate
        public DbSet<AvailableProductOptionTariffInTariff> AvailableProductOptionTariffInTariffs { get; set; }
        public DbSet<AvailableTariffForUpgrade> AvailableTariffForUpgrades { get; set; }
        public DbSet<IncludedProductInTariff> IncludedProductInTariffs { get; set; }
        public DbSet<IncludedProductOptionInTariff> IncludedProductOptionInTariffs { get; set; }
        public DbSet<TariffPrice> TariffPrices { get; set; }
        public DbSet<Tariff> Tariffs { get; set; }
        public DbSet<TariffAdvancePrice> TariffAdvancePrices { get; set; }
        public DbSet<TariffToContractKindBinding> TariffToContractKindBindings { get; set; }

        //TermsOfUse
        public DbSet<TermsOfUse> TermsOfUses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder )
        {
            base.OnModelCreating(builder);

            // Application
            builder.ApplyConfiguration(new ApplicationMap());
            builder.HasSequence<int>(HiLoSequence.DBSequenceHiLoForApplication).StartsAt(1)
                .IncrementsBy(1);

            //ApplicationSettingAggregate
            builder.ApplyConfiguration(new ApplicationSettingSetMap());
            builder.HasSequence<int>(HiLoSequence.DBSequenceHiLoForApplicationSettingSet).StartsAt(1)
                .IncrementsBy(1);
            builder.ApplyConfiguration(new ApplicationSettingValueMap());
            builder.HasSequence<int>(HiLoSequence.DBSequenceHiLoForApplicationSettingValue).StartsAt(1)
                .IncrementsBy(1);
            builder.ApplyConfiguration(new ApplicationSettingMap());
            builder.HasSequence<int>(HiLoSequence.DBSequenceHiLoForApplicationSetting).StartsAt(1)
                .IncrementsBy(1);
            builder.ApplyConfiguration(new ApplicationSettingPresetMap());
            builder.HasSequence<int>(HiLoSequence.DBSequenceHiLoForApplicationSettingPreset).StartsAt(1)
                .IncrementsBy(1);

            //BillingSettingAggregate
            builder.ApplyConfiguration(new BillingSettingMap());
            builder.HasSequence<int>(HiLoSequence.DBSequenceHiLoForBillingSetting).StartsAt(1)
                .IncrementsBy(1);
            builder.ApplyConfiguration(new BillingSettingPresetMap());
            builder.HasSequence<int>(HiLoSequence.DBSequenceHiLoForBillingSettingPreset).StartsAt(1)
                .IncrementsBy(1);
            builder.ApplyConfiguration(new BillingSettingSetMap());
            builder.HasSequence<int>(HiLoSequence.DBSequenceHiLoForBillingSettingSet).StartsAt(1)
                .IncrementsBy(1);

            //Currency
            builder.ApplyConfiguration(new CurrencyMap());
            builder.HasSequence<int>(HiLoSequence.DBSequenceHiLoForCurrency).StartsAt(1)
                .IncrementsBy(1);

            //SettingAggregate
            builder.ApplyConfiguration(new SettingMap());
            builder.HasSequence<int>(HiLoSequence.DBSequenceHiLoForSetting).StartsAt(1)
                .IncrementsBy(1);
            builder.ApplyConfiguration(new SettingEnumValueMap());
            builder.HasSequence<int>(HiLoSequence.DBSequenceHiLoForSettingEnumValue).StartsAt(1)
                .IncrementsBy(1);
            builder.ApplyConfiguration(new SettingsPresetMap());
            builder.HasSequence<int>(HiLoSequence.DBSequenceHiLoForSettingsPreset).StartsAt(1)
                .IncrementsBy(1);
            builder.ApplyConfiguration(new SettingsSetMap());
            builder.HasSequence<int>(HiLoSequence.DBSequenceHiLoForSettingsSet).StartsAt(1)
                .IncrementsBy(1);

            //TariffAgregate
            builder.ApplyConfiguration(new AvailableProductOptionTariffInTariffMap());
            builder.HasSequence<int>(HiLoSequence.DBSequenceHiLoForAvailableProductOptionTariffInTariff).StartsAt(1)
                .IncrementsBy(1);
            builder.ApplyConfiguration(new AvailableTariffForUpgradeMap());
            builder.HasSequence<int>(HiLoSequence.DBSequenceHiLoForAvailableTariffForUpgrade).StartsAt(1)
                .IncrementsBy(1);
            builder.ApplyConfiguration(new IncludedProductInTariffMap());
            builder.HasSequence<int>(HiLoSequence.DBSequenceHiLoForIncludedProductInTariff).StartsAt(1)
                .IncrementsBy(1);
            builder.ApplyConfiguration(new IncludedProductOptionInTariffMap());
            builder.HasSequence<int>(HiLoSequence.DBSequenceHiLoForIncludedProductOptionInTariff).StartsAt(1)
                .IncrementsBy(1);
            builder.ApplyConfiguration(new TariffMap());
            builder.HasSequence<int>(HiLoSequence.DBSequenceHiLoForTariff).StartsAt(1)
                .IncrementsBy(1);
            builder.ApplyConfiguration(new TariffAdvancePriceMap());
            builder.HasSequence<int>(HiLoSequence.DBSequenceHiLoForTariffAdvancePrice).StartsAt(1)
                .IncrementsBy(1);
            builder.ApplyConfiguration(new TariffPriceMap());
            builder.HasSequence<int>(HiLoSequence.DBSequenceHiLoForTariffPrice).StartsAt(1)
                .IncrementsBy(1);
            builder.ApplyConfiguration(new TariffToContractKindBindingMap());
            builder.HasSequence<int>(HiLoSequence.DBSequenceHiLoForTariffToContractKindBinding).StartsAt(1)
                .IncrementsBy(1);

            //ProductAggregate
            builder.ApplyConfiguration(new ProductMap());
            builder.HasSequence<int>(HiLoSequence.DBSequenceHiLoForProduct).StartsAt(1)
                .IncrementsBy(1);

            //ProductOptionKindAggregate
            builder.ApplyConfiguration(new ProductOptionKindMap());
            builder.HasSequence<int>(HiLoSequence.DBSequenceHiLoForProductOptionKind).StartsAt(1)
                .IncrementsBy(1);

            //ProductOptionAggregate
            builder.ApplyConfiguration(new ProductOptionMap());
            builder.HasSequence<int>(HiLoSequence.DBSequenceHiLoForProductOption).StartsAt(1)
                .IncrementsBy(1);

            //ProductOptionTariffAggregate
            builder.ApplyConfiguration(new ProductOptionTariffPriceMap());
            builder.HasSequence<int>(HiLoSequence.DBSequenceHiLoForProductOptionTariffPrice).StartsAt(1)
                .IncrementsBy(1);
            builder.ApplyConfiguration(new ProductOptionTariffMap());
            builder.HasSequence<int>(HiLoSequence.DBSequenceHiLoForProductOptionTariff).StartsAt(1)
                .IncrementsBy(1);

            // TermsOfUse
            builder.ApplyConfiguration(new TermsOfUseMap());
            builder.HasSequence<int>(HiLoSequence.DBSequenceHiLoForTermsOfUse).StartsAt(1)
                .IncrementsBy(1);

            foreach (var property in builder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties()))
            {
                if (property.ClrType == typeof(decimal) || property.ClrType == typeof(decimal?))
                {
                    //property.Relational().ColumnType = "decimal(19, 4)";
                }
                else if (property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?))
                {
                    property.SetValueConverter(
                        new ValueConverter<DateTime, DateTime>(
                            v => v,
                            v => DateTime.SpecifyKind(v, DateTimeKind.Utc)));

                    if (property.ValueGenerated != ValueGenerated.Never)
                    {
                        property.SetValueGeneratorFactory((_, __) => new DateTimeNowGenerator());
                    }
                }
            }
        }
    }
}
