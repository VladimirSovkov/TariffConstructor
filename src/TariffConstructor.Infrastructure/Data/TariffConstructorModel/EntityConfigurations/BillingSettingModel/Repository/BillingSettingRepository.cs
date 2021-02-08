using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TariffConstructor.Domain.BillingSettingModel;
using TariffConstructor.Toolkit.Pagination;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.BillingSettingModel.Repository
{
    public class BillingSettingRepository : IBillingSettingRepository
    {
        private readonly TariffConstructorContext _ctx;

        public BillingSettingRepository(TariffConstructorContext appDbContext)
        {
            _ctx = appDbContext;
        }

        public Task Add(BillingSetting entity)
        {
            _ctx.AddAsync(entity);
            return Task.CompletedTask;
        }

        public async Task Delete(int id)
        {
            BillingSetting billingSetting = await _ctx.BillingSettings.FirstOrDefaultAsync(x => x.Id == id);
            if (billingSetting != null)
            {
                _ctx.BillingSettings.Remove(billingSetting);
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

        public Task Update(BillingSetting setting)
        {
            _ctx.Entry(setting).State = EntityState.Modified;
            return Task.CompletedTask;
        }
    }
}
