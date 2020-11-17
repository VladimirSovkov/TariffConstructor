using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TariffConstructor.Domain.TariffAggregate;
using TariffConstructor.Domain.ValueObjects;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.TariffAgregate.Repository
{
    class TariffRepository : ITariffRepository
    {

        private readonly TariffConstructorContext _DbContext;

        public TariffRepository(TariffConstructorContext appDbContext)
        {
            _DbContext = appDbContext;
        }

        public Task<Tariff> AddTariff(Tariff entity)
        {
            Tariff tariff = new Tariff("name", PaymentType.Commission, "1");
            tariff.Archive();
            tariff.SetAwaitingPaymentStrategy("pyment strategy");
            tariff.SetSettingsPresetId(1);
            tariff.SetTermsOfUseId(1);
            tariff.SetAccountingTariffId("tariffId");
            TariffTestPeriod tariffTestPeriod = new TariffTestPeriod(1, TariffTestPeriodUnit.Day);
            tariff.AddTestPeriod(tariffTestPeriod);
            _DbContext.AddAsync(tariff);
            _DbContext.SaveChanges();

            return Task.FromResult<Tariff>(tariff);
        }

        public Task<Dictionary<int, List<int>>> GetAllProductIdsGroupByTariffId(params int[] tariffIds)
        {
            throw new NotImplementedException();
        }

        public Task<int[]> GetIncludedProductIdsInProductOptionTariffs(params int[] productOptionTariffIds)
        {
            throw new NotImplementedException();
        }

        public Task<int[]> GetIncludedProductIdsInTariffs(params int[] tariffIds)
        {
            throw new NotImplementedException();
        }

        public Task<Tariff> GetTariff(int tariffId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Tariff>> GetTariffs(params int[] tariffIds)
        {
            throw new NotImplementedException();
        }

        public Task<List<Tariff>> GetTariffsWithAcceptanceRequired()
        {
            var abc = _DbContext.Tariffs.ToListAsync();
            return abc;
        }
    }
}
