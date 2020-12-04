using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TariffConstructor.Domain.ProductOptionAggregate;
using TariffConstructor.Domain.SearchPattern;
using TariffConstructor.Toolkit.Search;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ProductOptionAggregate.Repository
{
    public class ProductOptionRepository : IProductOptionRepository
    {
        private readonly TariffConstructorContext _ctx;

        public ProductOptionRepository(TariffConstructorContext appDbContext)
        {
            _ctx = appDbContext;
        }

        public Task<ProductOption> AddTariff(ProductOption entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<ProductOption> GetProductOption(int productOptionId)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<ProductOption>> GetProductOptions(int[] productOptionIds)
        {
            throw new System.NotImplementedException();
        }

        public async Task<SearchResult<ProductOption>> Search(ProductOptionSearchPattern searchPattern)
        {
            IQueryable<ProductOption> query = _ctx.ProductOptions.AsQueryable();
            int totalCount = query.Count();

            // filters
            if (!String.IsNullOrWhiteSpace(searchPattern.SearchString))
            {
                string searchString = searchPattern.SearchString.Trim();
                query = query.Where(x =>
                   x.Name.Contains(searchString));
            }

            // sorting
            query = query.OrderByDescending(x => x.Id);

            int filteredCount = query.Count();

            // taking
            query = query.Skip(searchPattern.Skip()).Take(searchPattern.Take());

            return new SearchResult<ProductOption>
            {
                Items = await query.ToListAsync(),
                TotalCount = totalCount,
                FilteredCount = filteredCount
            };
        }
    }
}
