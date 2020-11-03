using TariffConstructor.Domain.TariffAggregate;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.TariffAgregate.Interface;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.TariffAgregate.Repository
{
    public class TariffTestPeriodRepository : ITariffTestPeriod
    {
        private readonly TariffConstructorContext _DbContext;

        public TariffTestPeriodRepository(TariffConstructorContext appDbContext)
        {
            _DbContext = appDbContext;
        }
        public void AddElement()
        {
            //TariffTestPeriod tariffTestPeriod = new TariffTestPeriod(1);
            //_DbContext.AddRange(tariffTestPeriod);
            //_DbContext.SaveChanges();
        }
    }
}
