﻿namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.TariffModel.Repository
{
    public class IncludedProductInTariffRepository 
    {
        private readonly TariffConstructorContext _DbContext;

        public IncludedProductInTariffRepository(TariffConstructorContext appDbContext)
        {
            _DbContext = appDbContext;
        }

        public void AddElement()
        {
            //IncludedProductInTariff includedProductInTariff = new IncludedProductInTariff(1);
            //includedProductInTariff.TariffId = 1;
            //includedProductInTariff.RelativeWeight = 1;
            //includedProductInTariff.Id = 1;

            //Product product = new Product("name", "1", "name");
            //product.NomenclatureId = "1";
            //product.Id = 1;
            //product.TenantId = 1;
            //product.CreationDate = new DateTime(2020, 10, 22);
            //includedProductInTariff.Product = product;
            //_DbContext.IncludedProductInTariff.AddRange(includedProductInTariff);
            //_DbContext.SaveChanges();
        }
    }
}
