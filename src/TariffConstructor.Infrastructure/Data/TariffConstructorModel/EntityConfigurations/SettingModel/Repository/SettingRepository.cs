using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TariffConstructor.Domain.SettingModel;
using TariffConstructor.Toolkit.Search;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.SettingModel.Repository
{
    public class SettingRepository : ISettingRepository
    {
        private readonly TariffConstructorContext _ctx;

        public SettingRepository(TariffConstructorContext appDbContext)
        {
            _ctx = appDbContext;
        }

        public Task Add(Setting entity)
        {
            _ctx.AddAsync(entity);
            return Task.CompletedTask;
        }

        public async Task Delete(int id)
        {
            Setting setting = await _ctx.Settings.FirstOrDefaultAsync(x => x.Id == id);
            if (setting != null)
            {
                _ctx.Settings.Remove(setting);
                await _ctx.SaveChangesAsync();
            }
        }

        public Task<Setting> GetSetting(int id)
        {
            return _ctx.Settings.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<Setting>> GetSettings()
        {
            List<Setting> settings = await _ctx.Settings.ToListAsync();
            return settings;
        }

        public async Task<SearchResult<Setting>> Search(SettingSearchPattern searchPattern)
        {
            IQueryable<Setting> query = _ctx.Settings.AsQueryable();
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

            return new SearchResult<Setting>
            {
                Items = await query.ToListAsync(),
                TotalCount = totalCount,
                FilteredCount = filteredCount
            };
        }

        public Task Update(Setting setting)
        {
            _ctx.Entry(setting).State = EntityState.Modified;
            return Task.CompletedTask;
        }
    }
}
