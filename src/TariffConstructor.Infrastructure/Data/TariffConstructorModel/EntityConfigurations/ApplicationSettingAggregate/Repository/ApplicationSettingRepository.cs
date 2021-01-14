using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TariffConstructor.Domain.ApplicationSettingAggregate;
using TariffConstructor.Domain.PaginationPattern;
using TariffConstructor.Domain.SearchPattern;
using TariffConstructor.Toolkit.Pagination;
using TariffConstructor.Toolkit.Search;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ApplicationSettingAggregate.Repository
{
    public class ApplicationSettingRepository : IApplicationSettingRepository
    {
        private readonly TariffConstructorContext _ctx;

        public ApplicationSettingRepository(TariffConstructorContext appDbContext)
        {
            _ctx = appDbContext;
        }

        public Task<ApplicationSetting> Add(ApplicationSetting entity)
        {
            _ctx.AddAsync(entity);
            _ctx.SaveChanges();

            return Task.FromResult<ApplicationSetting>(entity);
        }

        public async Task Delete(int id)
        {
            ApplicationSetting applicationSetting = await _ctx.ApplicationSettings.FirstOrDefaultAsync(x => x.Id == id);
            if (applicationSetting != null)
            {
                _ctx.ApplicationSettings.Remove(applicationSetting);
                await _ctx.SaveChangesAsync();
            }
        }

        public Task<ApplicationSetting> GetApplicationSetting(int id)
        {
            return _ctx.ApplicationSettings.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ApplicationSetting>> GetApplicationSettings()
        {
            return await _ctx.ApplicationSettings.ToListAsync();
        }

        public async Task<PaginationResult<ApplicationSetting>> Pagination(ApplicationSettingPaginationPattern searchPattern)
        {
            IQueryable<ApplicationSetting> query = _ctx.ApplicationSettings.AsQueryable();
            int totalCount = query.Count();

            // sorting
            query = query.OrderByDescending(x => x.Id);

            // taking
            query = query.Skip(searchPattern.Skip()).Take(searchPattern.Take());

            return new PaginationResult<ApplicationSetting>
            {
                Items = await query.ToListAsync(),
                TotalCount = totalCount
            };
        }

        public Task<ApplicationSetting> Update(ApplicationSetting applicationSetting)
        {
            _ctx.Entry(applicationSetting).State = EntityState.Modified;
            _ctx.SaveChanges();

            return Task.FromResult<ApplicationSetting>(applicationSetting);
        }
    }
}
