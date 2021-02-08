using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TariffConstructor.Domain.ContractKindModel;
using TariffConstructor.Toolkit.Search;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ContractKindModel.Repository
{
    public class ContractKindRepository : IContractKindRepository
    {
        private readonly TariffConstructorContext _ctx;

        public ContractKindRepository(TariffConstructorContext appDbContext)
        {
            _ctx = appDbContext;
        }

        public Task Add(ContractKind contractKind)
        {
            _ctx.AddAsync(contractKind);
            return Task.CompletedTask;
        }

        public async Task Delete(int id)
        {
            ContractKind contractKind = await _ctx.ContractKinds.FirstOrDefaultAsync(x => x.Id == id);
            if (contractKind != null)
            {
                _ctx.ContractKinds.Remove(contractKind);
            }
        }

        public Task<ContractKind> GetContractKind(int id)
        {
            return _ctx.ContractKinds.FirstOrDefaultAsync(x => x.Id == id);

        }

        public Task<ContractKind> GetContractKind(string publicId)
        {
            return _ctx.ContractKinds.FirstOrDefaultAsync(x => x.PublicId == publicId);
        }

        public async Task<List<ContractKind>> GetContractKinds()
        {
            return await _ctx.ContractKinds.ToListAsync();
        }

        public async Task<SearchResult<ContractKind>> Search(ContractKindSearchPattern searchPattern)
        {
            IQueryable<ContractKind> query = _ctx.ContractKinds.AsQueryable();
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

            return new SearchResult<ContractKind>
            {
                Items = await query.ToListAsync(),
                TotalCount = totalCount,
                FilteredCount = filteredCount
            };
        }

        public Task Update(ContractKind contractKind)
        {
            _ctx.Entry(contractKind).State = EntityState.Modified;
            return Task.CompletedTask;
        }
    }
}
