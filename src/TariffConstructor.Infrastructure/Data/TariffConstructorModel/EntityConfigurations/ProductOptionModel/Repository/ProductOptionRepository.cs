using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TariffConstructor.Domain.ProductOptionModel;
using TariffConstructor.Domain.SearchPattern;
using TariffConstructor.Toolkit.Search;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ProductOptionModel.Repository
{
    public class ProductOptionRepository : IProductOptionRepository
    {
        private readonly TariffConstructorContext _ctx;

        public ProductOptionRepository(TariffConstructorContext appDbContext)
        {
            _ctx = appDbContext;
        }

        public Task<ProductOption> Add(ProductOption entity)
        {
            _ctx.AddAsync(entity);
            _ctx.SaveChanges();

            return Task.FromResult<ProductOption>(entity);
        }

        public async Task Delete(int id)
        {
            ProductOption productOption = await _ctx.ProductOptions.FirstOrDefaultAsync(x => x.Id == id);
            if (productOption != null)
            {
                _ctx.ProductOptions.Remove(productOption);
                await _ctx.SaveChangesAsync();
            }
        }

        public Task<ProductOption> GetProductOption(int productOptionId)
        {
            return _ctx.ProductOptions.FirstOrDefaultAsync(x => x.Id == productOptionId);
        }

        public Task<ProductOption> GetProductOption(string publicId)
        {
            return _ctx.ProductOptions.FirstOrDefaultAsync(x => x.PublicId == publicId);
        }

        public Task<List<ProductOption>> GetProductOptions(int[] productOptionIds)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<ProductOption>> GetProductOptions()
        {
            return _ctx.ProductOptions.ToListAsync();
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

        public Task<ProductOption> Update(ProductOption entity)
        {
            var productOptions = _ctx.ProductOptions.FirstOrDefault(x => x.Id == entity.Id);
            productOptions.SetName(entity.Name);
            productOptions.SetAccountingName(entity.AccountingName);
            productOptions.SetIsMultiple(entity.IsMultiple);
            productOptions.SetNomenclatureId(entity.NomenclatureId);
            productOptions.SetProductId(entity.ProductId);
            _ctx.Entry(productOptions).State = EntityState.Modified;
            _ctx.SaveChanges();

            return Task.FromResult<ProductOption>(productOptions);
        }
    }
}
