﻿using TariffConstructor.Domain.TariffModel;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.TariffModel.Repository
{
    public class TariffTestPeriodRepository 
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
