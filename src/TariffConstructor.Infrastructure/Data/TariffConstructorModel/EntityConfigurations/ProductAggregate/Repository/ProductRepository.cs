using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TariffConstructor.Domain.ProductModel;
using TariffConstructor.Domain.SearchPattern;
using TariffConstructor.Toolkit.Search;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations
{
    public class ProductRepository : IProductRepository
    {
        private readonly TariffConstructorContext _ctx;

        public ProductRepository(TariffConstructorContext appDbContext)
        {
            _ctx = appDbContext;
        }

        public Task<Product> Add(Product entity)
        {
            _ctx.AddAsync(entity);
            _ctx.SaveChanges();

            return Task.FromResult<Product>(entity);
        }

        public async Task<SearchResult<Product>> Search(ProductSearchPattern searchPattern)
        {
            IQueryable<Product> query = _ctx.Products.AsQueryable();
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

            return new SearchResult<Product>
            {
                Items = await query.ToListAsync(),
                TotalCount = totalCount,
                FilteredCount = filteredCount
            };
        }

        public Task<Product> GetProduct(int id)
        {
            return _ctx.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<Product>> GetProducts(IEnumerable<int> productIds)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Product>> GetProducts()
        {
            List<Product> products = await _ctx.Products.ToListAsync();
            return products;
        }

        public Task<Product> Update(Product product)
        {
            _ctx.Entry(product).State = EntityState.Modified;
            _ctx.SaveChanges();

            return Task.FromResult<Product>(product);
        }

        public async Task Delete(int id)
        {
            Product product = await _ctx.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product != null)
            {
                _ctx.Products.Remove(product);
                await _ctx.SaveChangesAsync();
            }
        }
    }
}
