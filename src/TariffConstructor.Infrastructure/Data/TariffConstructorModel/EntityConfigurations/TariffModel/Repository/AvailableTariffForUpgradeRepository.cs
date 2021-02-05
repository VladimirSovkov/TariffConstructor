using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TariffConstructor.Domain.TariffModel;
using TariffConstructor.Toolkit.Pagination;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.TariffModel.Repository
{
    public class AvailableTariffForUpgradeRepository : IAvailableTariffForUpgradeRepository
    {
        private readonly TariffConstructorContext _ctx;
        public AvailableTariffForUpgradeRepository(TariffConstructorContext appDbContext)
        {
            _ctx = appDbContext;
        }

        public Task Add(AvailableTariffForUpgrade entity)
        {
            _ctx.AddAsync(entity);
            return Task.CompletedTask;
        }

        public async Task Delete(int id)
        {
            AvailableTariffForUpgrade availableTariffForUpgrade = await _ctx.AvailableTariffForUpgrades.FirstOrDefaultAsync(x => x.Id == id);
            if (availableTariffForUpgrade != null)
            {
                _ctx.AvailableTariffForUpgrades.Remove(availableTariffForUpgrade);
            }
        }

        public async Task<AvailableTariffForUpgrade> GetAvailableTariffForUpgrade(int id)
        {
            return await _ctx.AvailableTariffForUpgrades.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<AvailableTariffForUpgrade>> GetAvailableTariffForUpgrades()
        {
            return await _ctx.AvailableTariffForUpgrades.ToListAsync();
        }

        public async Task<PaginationResult<AvailableTariffForUpgrade>> Serach(AvailableTariffForUpgradePaginationPattern searchPattern)
        {
            IQueryable<AvailableTariffForUpgrade> query = _ctx.AvailableTariffForUpgrades.AsQueryable();

            int totalCount = query.Count();

            query = query.OrderByDescending(x => x.Id);

            query = query.Skip(searchPattern.Skip()).Take(searchPattern.Take());

            return new PaginationResult<AvailableTariffForUpgrade>
            {
                Items = await query.ToListAsync(),
                TotalCount = totalCount
            };
        }

        public Task Update(AvailableTariffForUpgrade entity)
        {
            _ctx.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }
    }
}
