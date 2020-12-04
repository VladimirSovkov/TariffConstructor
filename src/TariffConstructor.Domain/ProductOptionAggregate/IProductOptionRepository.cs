﻿using System.Collections.Generic;
using System.Threading.Tasks;
using TariffConstructor.Domain.SearchPattern;
using TariffConstructor.Toolkit.Abstractions;
using TariffConstructor.Toolkit.Search;

namespace TariffConstructor.Domain.ProductOptionAggregate
{
    public interface IProductOptionRepository : IRepository<ProductOption>
    {
        Task<ProductOption> GetProductOption( int productOptionId );

        Task<List<ProductOption>> GetProductOptions( int[] productOptionIds );

        Task<SearchResult<ProductOption>> Search(ProductOptionSearchPattern searchPattern);
    }
}
