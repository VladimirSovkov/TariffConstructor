using System;
using System.Collections.Generic;
using System.Text;
using TariffConstructor.Domain.TariffAggregate;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations
{
    public class IncludedProductInTariffRepository : IIncludedProductInTariff
    {
        private readonly TariffConstructorContext _DbContext;

        public IncludedProductInTariffRepository(TariffConstructorContext appDbContext)
        {
            _DbContext = appDbContext;
        }

        public void AddElement()
        {
            IncludedProductInTariff includedProductInTariff = new IncludedProductInTariff(1);
            includedProductInTariff.TariffId = 1;
            includedProductInTariff.RelativeWeight = 1;
            includedProductInTariff.Id = 1;
            //_DbContext.IncludedProductInTariff.AddRange(includedProductInTariff);
            _DbContext.SaveChanges();
        }
    }
}
