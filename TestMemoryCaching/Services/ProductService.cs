

using Microsoft.Extensions.Caching.Memory;
using System.Data.Entity;
using TestMemoryCaching.Entities;
using TestMemoryCaching.Repositories;

namespace TestMemoryCaching.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;
        private readonly IMemoryCache _memoryCache;
        public ProductService()
        {

        }
        public async Task<List<Product>> GetAll(CancellationToken cancellation)
        {
           return await _context.Product.OrderBy(x=>x.Name).ToListAsync(cancellation);
        }
    }
}
