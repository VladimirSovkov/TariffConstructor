using System;
using TariffConstructor.Domain.TariffAggregate;
using TariffConstructor.Domain.ValueObjects;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.TariffAgregate.Interface;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.TariffAgregate.Repository
{
    class TariffRepository : ITariffRepostitory
    {

        private readonly TariffConstructorContext _DbContext;

        public TariffRepository(TariffConstructorContext appDbContext)
        {
            _DbContext = appDbContext;
        }
        public void AddElement()
        {
            Tariff tariff = new Tariff("name", "publicId");
            tariff.CreationDate = DateTime.Now;
            tariff.Archive();
            tariff.SetAwaitingPaymentStrategy("strategy");
            tariff.SetAccountingTariffId("tariff id");
            tariff.SetSettingsPresetId(1);
            tariff.SetTermsOfUseId(1);
            tariff.IsAcceptanceRequired = true;
            tariff.IsGradualFinishAvailable = false;
            //_DbContext.Tariff.AddRange(tariff);
            //_DbContext.SaveChanges();
        }
    }
}
