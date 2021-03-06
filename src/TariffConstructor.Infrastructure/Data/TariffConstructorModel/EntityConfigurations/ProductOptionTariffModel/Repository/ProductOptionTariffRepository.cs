﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TariffConstructor.Domain.ProductOptionTariffModel;
using TariffConstructor.Toolkit.Search;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ProductOptionTariffModel.Repository
{
    class ProductOptionTariffRepository : IProductOptionTariffRepository
    {
        private readonly TariffConstructorContext _ctx;
        
        public ProductOptionTariffRepository(TariffConstructorContext appDbContext)
        {
            _ctx = appDbContext;
        }

        public Task Add(ProductOptionTariff productOptionTariff)
        {
            _ctx.AddAsync(productOptionTariff);
            return Task.CompletedTask;
        }

        public async Task Delete(int id)
        {
            ProductOptionTariff productOptionTariff = await _ctx.ProductOptionTariffs.FirstOrDefaultAsync(x => x.Id == id);
            if (productOptionTariff != null)
            {
                _ctx.ProductOptionTariffs.Remove(productOptionTariff);
            }
        }

        public Task<ProductOptionTariff> GetProductOptionTariff(int id)
        {
            return _ctx.ProductOptionTariffs.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<SearchResult<ProductOptionTariff>> Search(ProductOptionTariffSearchPattern searchPattern)
        {
            IQueryable<ProductOptionTariff> query = _ctx.ProductOptionTariffs.AsQueryable();
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

            return new SearchResult<ProductOptionTariff>
            {
                Items = await query.ToListAsync(),
                TotalCount = totalCount,
                FilteredCount = filteredCount
            };
        }

        public Task Update(ProductOptionTariff productOptionTariff)
        {
            _ctx.Entry(productOptionTariff).State = EntityState.Modified;
            return Task.CompletedTask;
        }
    }
}
