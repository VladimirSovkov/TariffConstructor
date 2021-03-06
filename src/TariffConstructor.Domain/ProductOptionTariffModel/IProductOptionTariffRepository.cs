﻿using System.Collections.Generic;
using System.Threading.Tasks;
using TariffConstructor.Toolkit.Abstractions;
using TariffConstructor.Toolkit.Search;

namespace TariffConstructor.Domain.ProductOptionTariffModel
{
    public interface IProductOptionTariffRepository : IRepository<ProductOptionTariff>
    {
        Task<ProductOptionTariff> GetProductOptionTariff(int id);
        Task<SearchResult<ProductOptionTariff>> Search(ProductOptionTariffSearchPattern searchPattern); 
    }
}
