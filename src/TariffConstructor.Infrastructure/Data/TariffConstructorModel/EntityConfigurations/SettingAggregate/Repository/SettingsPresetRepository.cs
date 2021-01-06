using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TariffConstructor.Domain.SearchPattern;
using TariffConstructor.Domain.SettingAggregate;
using TariffConstructor.Toolkit.Search;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.SettingAggregate.Repository
{
    public class SettingsPresetRepository : ISettingsPresetRepository
    {
        private readonly TariffConstructorContext _ctx;

        public SettingsPresetRepository(TariffConstructorContext appDbContext)
        {
            _ctx = appDbContext;
        }

        public Task<SettingsPreset> Add(SettingsPreset entity)
        {
            _ctx.AddAsync(entity);
            _ctx.SaveChanges();

            return Task.FromResult<SettingsPreset>(entity);
        }

        public async Task Delete(int id)
        {
            SettingsPreset settingsPreset = await _ctx.SettingsPresets.FirstOrDefaultAsync(x => x.Id == id);
            if (settingsPreset != null)
            {
                _ctx.SettingsPresets.Remove(settingsPreset);
                await _ctx.SaveChangesAsync();
            }
        }

        public Task<SettingsPreset> GetSettingsPreset(int id)
        {
            return _ctx.SettingsPresets.FirstOrDefaultAsync(x => x.Id == id);
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

        public Task<SettingsPreset> Update(SettingsPreset setting)
        {
            _ctx.Entry(setting).State = EntityState.Modified;
            _ctx.SaveChanges();

            return Task.FromResult<SettingsPreset>(setting);
        }
    }
}
