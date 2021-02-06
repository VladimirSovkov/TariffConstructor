using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TariffConstructor.Domain.TariffModel;
using TariffConstructor.Toolkit.Search;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.TariffModel.Repository
{
    class TariffRepository : ITariffRepository
    {

        private readonly TariffConstructorContext _DbContext;

        public TariffRepository(TariffConstructorContext appDbContext)
        {
            _DbContext = appDbContext;
        }

        public Task Add(Tariff tariff)
        {
            _DbContext.AddAsync(tariff);
            _DbContext.SaveChanges();

            return Task.CompletedTask;
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
            return _DbContext.Tariffs.FirstOrDefaultAsync(x => x.Id == tariffId);
        }

        public Task<List<Tariff>> GetTariffs(params int[] tariffIds)
        {
            throw new NotImplementedException();
        }

        public async Task<SearchResult<Tariff>> GetFoundTariff(TarifftSearchPattern searchPattern)
        {
            IQueryable<Tariff> query = _DbContext.Tariffs.AsQueryable();

            int totalCount = query.Count();

            if (!String.IsNullOrWhiteSpace(searchPattern.SearchString))
            {
                string searchString = searchPattern.SearchString.Trim();
                query = query.Where(x =>
                   x.Name.Contains(searchString));
            }

            query = query.OrderByDescending(x => x.Id);

            int filteredCount = query.Count();

            query = query.Skip(searchPattern.Skip()).Take(searchPattern.Take());

            return new SearchResult<Tariff>
            {
                Items = await query.ToListAsync(),
                TotalCount = totalCount,
                FilteredCount = filteredCount
            };
        }

        public Task Update(Tariff tariff)
        {
            _DbContext.Entry(tariff).State = EntityState.Modified;
            _DbContext.SaveChanges();

            return Task.CompletedTask;
        }

        public async Task Delete(int id)
        {
            Tariff tariff = await _DbContext.Tariffs.FirstOrDefaultAsync(x => x.Id == id);
            if (tariff != null)
            {
                _DbContext.Tariffs.Remove(tariff);
                await _DbContext.SaveChangesAsync();
            }
        }

        public Task<Tariff> GeTariffFirstOrDefaultSettingPreset(int settingPresetId)
        {
            return _DbContext.Tariffs.FirstOrDefaultAsync(x => x.SettingsPresetId == settingPresetId);
        }

        public Task<Tariff> GeTariffFirstOrDefaulTermsOfUse(int termsOfUseId)
        {
            return _DbContext.Tariffs.FirstOrDefaultAsync(x => x.TermsOfUseId == termsOfUseId);
        }

        public async Task<List<Tariff>> GetTariffs()
        {
            return await _DbContext.Tariffs.ToListAsync();
        }
    }
}
