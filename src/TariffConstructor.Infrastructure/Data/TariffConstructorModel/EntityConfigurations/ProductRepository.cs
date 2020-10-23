using System;
using System.Collections.Generic;
using System.Text;
using TariffConstructor.Infrastructure.Data;
using TariffConstructor.Domain.ProductAggregate;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.Interface;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations
{
    public class ProductRepository : IProduct
    {
        private readonly TariffConstructorContext _DbContext;

        public ProductRepository(TariffConstructorContext appDbContext)
        {
            _DbContext = appDbContext;
        }
        public void AddElement()
        {
            Product product = new Product("name", "1", "name" );
            product.NomenclatureId = "1";
            product.TenantId = 1;
            product.CreationDate = new DateTime(2020, 10, 22);
            _DbContext.Products.AddRange(product);
            _DbContext.SaveChanges();
        }
    }
}
