using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TariffConstructor.Domain.ApplicationSettingModel;
using TariffConstructor.Domain.SettingModel;
using TariffConstructor.Toolkit.Search;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.SettingModel.Repository
{
    public class SettingsPresetRepository : ISettingsPresetRepository
    {
        private readonly TariffConstructorContext _ctx;

        public SettingsPresetRepository(TariffConstructorContext appDbContext)
        {
            _ctx = appDbContext;
        }

        public Task Add(SettingsPreset entity)
        {
            _ctx.AddAsync(entity);
            return Task.CompletedTask;
        }

        public async Task Delete(int id)
        {
            SettingsPreset settingsPreset = await _ctx.SettingsPresets.FirstOrDefaultAsync(x => x.Id == id);
            if (settingsPreset != null)
            {
                _ctx.SettingsPresets.Remove(settingsPreset);
            }
        }

        public async Task<SettingsPreset> GetSettingsPreset(int id)
        {
            return await _ctx.SettingsPresets.Include(x => x.ApplicationSettingPresets)
                .Include(x => x.BillingSettingPresets)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<SettingsPreset>> GetSettingsPresets()
        {
            return await _ctx.SettingsPresets.ToListAsync();
        }

        public async Task<SearchResult<SettingsPreset>> Search(SettingsPresetSearchPattern searchPattern)
        {
            IQueryable<SettingsPreset> query = _ctx.SettingsPresets.AsQueryable();
            int totalCount = query.Count();

            // filters
            if (!String.IsNullOrWhiteSpace(searchPattern.SearchString))
            {
                string searchString = searchPattern.SearchString.Trim();
                query = query.Where(x => x.Name.Contains(searchString));
            }

            // sorting
            query = query.OrderByDescending(x => x.Id);

            int filteredCount = query.Count();

            // taking
            query = query.Skip(searchPattern.Skip()).Take(searchPattern.Take());

            return new SearchResult<SettingsPreset>
            {
                Items = await query.ToListAsync(),
                TotalCount = totalCount,
                FilteredCount = filteredCount
            };
        }

        public Task Update(SettingsPreset setting)
        {
            _ctx.Entry(setting).State = EntityState.Modified;
            return Task.CompletedTask;
        }
    }
}
