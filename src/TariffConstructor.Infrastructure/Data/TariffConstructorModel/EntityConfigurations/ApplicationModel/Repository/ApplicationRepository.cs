using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TariffConstructor.Domain.ApplicationModel;
using TariffConstructor.Domain.SearchPattern;
using TariffConstructor.Toolkit.Search;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ApplicationModel.Repository
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly TariffConstructorContext _ctx;

        public ApplicationRepository(TariffConstructorContext appDbContext)
        {
            _ctx = appDbContext;
        }

        public Task<Application> Add(Application application)
        {
            _ctx.AddAsync(application);
            _ctx.SaveChanges();

            return Task.FromResult<Application>(application);
        }

        public async Task Delete(int id)
        {
            Application application = await _ctx.Applications.FirstOrDefaultAsync(x => x.Id == id);
            if (application != null)
            {
                _ctx.Applications.Remove(application);
                await _ctx.SaveChangesAsync();
            }
        }

        public Task<Application> GetApplication(int id)
        {
            return _ctx.Applications.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Application> GetApplication(string publicId)
        {
            return await _ctx.Applications.FirstOrDefaultAsync(x => x.PublicId == publicId);
        }

        public async Task<List<Application>> GetApplications()
        {
            return await _ctx.Applications.ToListAsync();
        }

        public async Task<SearchResult<Application>> Search(ApplicationSearchPattern searchPattern)
        {
            IQueryable<Application> query = _ctx.Applications.AsQueryable();
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

            return new SearchResult<Application>
            {
                Items = await query.ToListAsync(),
                TotalCount = totalCount,
                FilteredCount = filteredCount
            };
        }

        public Task<Application> Update(Application application)
        {
            _ctx.Entry(application).State = EntityState.Modified;
            _ctx.SaveChanges();

            return Task.FromResult<Application>(application);
        }
    }
}
