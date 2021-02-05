using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TariffConstructor.Domain.TermsOfUseModel;
using TariffConstructor.Toolkit.Search;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.TermsOfUseModel.Repository
{
    public class TermsOfUseRepository : ITermsOfUseRepository
    {
        private readonly TariffConstructorContext _ctx;

        public TermsOfUseRepository(TariffConstructorContext appDbContext)
        {
            _ctx = appDbContext;
        }

        public Task Add(TermsOfUse entity)
        {
            _ctx.AddAsync(entity);
            _ctx.SaveChanges();

            return Task.CompletedTask;
        }

        public async Task Delete(int id)
        {
            TermsOfUse termsOfUse = await _ctx.TermsOfUses.FirstOrDefaultAsync(x => x.Id == id);
            if (termsOfUse != null)
            {
                _ctx.TermsOfUses.Remove(termsOfUse);
                _ctx.SaveChanges();
            }
        }

        public Task<TermsOfUse> GetTermsOfUse(int termsOfUseId)
        {
            return _ctx.TermsOfUses.FirstOrDefaultAsync(x => x.Id == termsOfUseId);
        }

        public Task<TermsOfUse> GetTermsOfUse(string publicId)
        {
            return _ctx.TermsOfUses.FirstOrDefaultAsync(x => x.PublicId == publicId);
        }

        public async Task<List<TermsOfUse>> GetTermsOfUses()
        {
            List<TermsOfUse> termsOfUses = await _ctx.TermsOfUses.ToListAsync();
            return termsOfUses;
        }

        public async Task<SearchResult<TermsOfUse>> Search(TermsOfUseSearchPattern searchPattern)
        {
            IQueryable<TermsOfUse> query = _ctx.TermsOfUses.AsQueryable();
            int totalCount = query.Count();

            // filters
            if (!String.IsNullOrWhiteSpace(searchPattern.SearchString))
            {
                string searchString = searchPattern.SearchString.Trim();
                query = query.Where(x =>
                   x.DocumentName.Contains(searchString));
            }

            // sorting
            query = query.OrderByDescending(x => x.Id);

            int filteredCount = query.Count();

            // taking
            query = query.Skip(searchPattern.Skip()).Take(searchPattern.Take());

            return new SearchResult<TermsOfUse>
            {
                Items = await query.ToListAsync(),
                TotalCount = totalCount,
                FilteredCount = filteredCount
            };
        }

        public Task Update(TermsOfUse termsOfUse)
        {
            _ctx.Entry(termsOfUse).State = EntityState.Modified;
            _ctx.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
