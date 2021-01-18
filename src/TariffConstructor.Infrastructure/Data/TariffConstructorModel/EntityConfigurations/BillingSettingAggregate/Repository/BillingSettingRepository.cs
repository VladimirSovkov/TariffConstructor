using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TariffConstructor.Domain.BillingSettingModel;
using TariffConstructor.Domain.PaginationPattern;
using TariffConstructor.Toolkit.Pagination;
using TariffConstructor.Toolkit.Search;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.BillingSettingAggregate.Repository
{
    public class BillingSettingRepository : IBillingSettingRepository
    {
        private readonly TariffConstructorContext _ctx;

        public BillingSettingRepository(TariffConstructorContext appDbContext)
        {
            _ctx = appDbContext;
        }

        public Task<BillingSetting> Add(BillingSetting entity)
        {
            _ctx.AddAsync(entity);
            _ctx.SaveChanges();

            return Task.FromResult<BillingSetting>(entity);
        }

        public async Task Delete(int id)
        {
            BillingSetting billingSetting = await _ctx.BillingSettings.FirstOrDefaultAsync(x => x.Id == id);
            if (billingSetting != null)
            {
                _ctx.BillingSettings.Remove(billingSetting);
                await _ctx.SaveChangesAsync();
            }
        }

        public Task<BillingSetting> GetBillingSetting(int id)
        {
            return _ctx.BillingSettings.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<BillingSetting>> GetBillingSettings()
        {
            List<BillingSetting> settings = await _ctx.BillingSettings.ToListAsync();
            return settings;
        }

        public async Task<PaginationResult<BillingSetting>> Pagination(BillingSettingPaginationPattern searchPattern)
        {
            IQueryable<BillingSetting> query = _ctx.BillingSettings.AsQueryable();
            int totalCount = query.Count();

            // sorting
            query = query.OrderByDescending(x => x.Id);

            // taking
            query = query.Skip(searchPattern.Skip()).Take(searchPattern.Take());

            return new PaginationResult<BillingSetting>
            {
                Items = await query.ToListAsync(),
                TotalCount = totalCount
            };
        }

        public Task<BillingSetting> Update(BillingSetting setting)
        {
            _ctx.Entry(setting).State = EntityState.Modified;
            _ctx.SaveChanges();

            return Task.FromResult<BillingSetting>(setting);
        }
    }
}
