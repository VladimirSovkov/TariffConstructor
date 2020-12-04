using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TariffConstructor.Domain.ContractModel;
using TariffConstructor.Domain.TariffAggregate;
using TariffConstructor.Domain.TariffAggregate.Toolkit;
using TariffConstructor.Domain.ValueObjects;
using TariffConstructor.Toolkit.PageApp;
using TariffConstructor.Toolkit.Search;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.TariffAgregate.Repository
{
    class TariffRepository : ITariffRepository
    {

        private readonly TariffConstructorContext _DbContext;

        public TariffRepository(TariffConstructorContext appDbContext)
        {
            _DbContext = appDbContext;
        }

        public Task<Tariff> AddTariff(Tariff tariff)
        {
            _DbContext.AddAsync(tariff);
            _DbContext.SaveChanges();

            return Task.FromResult<Tariff>(tariff);
        }

        public Task<Dictionary<int, List<int>>> GetAllProductIdsGroupByTariffId(params int[] tariffIds)
        {
            throw new NotImplementedException();
        }

        public Task<int[]> GetIncludedProductIdsInProductOptionTariffs(params int[] productOptionTariffIds)
        {
            throw new NotImplementedException();
        }

        public Task<int[]> GetIncludedProductIdsInTariffs(params int[] tariffIds)
        {
            throw new NotImplementedException();
        }

        public Task<Tariff> GetTariff(int tariffId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Tariff>> GetTariffs(params int[] tariffIds)
        {
            throw new NotImplementedException();
        }

        public async Task<TariffPaginator> GetTariffs(int countElementInPage, int page = 1)
        {
            IQueryable<Tariff> source = _DbContext.Tariffs;
            var count = await source.CountAsync();
            var items = await source.Skip((page - 1) * countElementInPage).Take(countElementInPage).ToListAsync();

            PageViewModel pageViewModel = new PageViewModel(count, page, countElementInPage);
            TariffPaginator viewModel = new TariffPaginator
            {
                PageViewModel = pageViewModel,
                Tariffs = items
            };
            return viewModel;
        }

        public Task<List<Tariff>> GetTariffsWithAcceptanceRequired()
        {
            var abc = _DbContext.Tariffs.ToListAsync();
            return abc;
        }

        public async Task<SearchResult<Tariff>> GetFoundRates(TarifftSearchPattern searchPattern)
        {
            IQueryable<Tariff> query = _DbContext.Tariffs.AsQueryable();

            int totalCount = query.Count();

            // filters
            if (!String.IsNullOrWhiteSpace(searchPattern.SearchString))
            {
                string searchString = searchPattern.SearchString.Trim();
                query = query.Where(x =>
                   x.Name.Contains(searchString)
                   /*|| x.AccountantEmailsSerialized.Contains(searchString)
                   || x.Profile.Name.Contains(searchString)*/);
            }

            // sorting

            query = query.OrderByDescending(x => x.Id);

            int filteredCount = query.Count();

            // taking
            query = query.Skip(searchPattern.Skip()).Take(searchPattern.Take());

            // include 
            //query = query.Include(x => x)
            //    .Include(x => x.)
            //    .Include(x => x.Kind.Company)
            //    .Include(x => x.Profile);

            return new SearchResult<Tariff>
            {
                Items = await query.ToListAsync(),
                TotalCount = totalCount,
                FilteredCount = filteredCount
            };
        }
    }
}
