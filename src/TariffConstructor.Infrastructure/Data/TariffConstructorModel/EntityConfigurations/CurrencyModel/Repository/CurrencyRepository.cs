﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TariffConstructor.Domain.CurrencyModel;
using TariffConstructor.Domain.SearchPattern;
using TariffConstructor.Toolkit.Search;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.CurrencyModel.Repository
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly TariffConstructorContext _ctx;

        public CurrencyRepository(TariffConstructorContext appDbContext)
        {
            _ctx = appDbContext;
        }
        public Task<Currency> Add(Currency currency)
        {
            _ctx.AddAsync(currency);
            _ctx.SaveChanges();

            return Task.FromResult<Currency>(currency);
        }

        public async Task Delete(int id)
        {
            Currency currency = await _ctx.Currencies.FirstOrDefaultAsync(x => x.Id == id);
            if (currency != null)
            {
                _ctx.Currencies.Remove(currency);
                await _ctx.SaveChangesAsync();
            }
        }

        public async Task<List<Currency>> GetCurrencies()
        {
            return await _ctx.Currencies.ToListAsync();
        }

        public Task<Currency> GetCurrency(int id)
        {
            return _ctx.Currencies.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<SearchResult<Currency>> Search(CurrencySearchPattern searchPattern)
        {
            IQueryable<Currency> query = _ctx.Currencies.AsQueryable();
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

            return new SearchResult<Currency>
            {
                Items = await query.ToListAsync(),
                TotalCount = totalCount,
                FilteredCount = filteredCount
            };
        }

        public Task<Currency> Update(Currency currency)
        {
            _ctx.Entry(currency).State = EntityState.Modified;
            _ctx.SaveChanges();

            return Task.FromResult<Currency>(currency);
        }
    }
}