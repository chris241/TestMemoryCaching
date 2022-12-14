

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using TestMemoryCaching.Entities;
using TestMemoryCaching.Repositories;

namespace TestMemoryCaching.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;
        private readonly IMemoryCache _memoryCache;
        public ProductService(DataContext context, IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;
        }
        public async Task<List<Product>> GetAll(CancellationToken cancellation)
        {
           return await _context.Product.OrderBy(x=>x.Name).ToListAsync(cancellation);
        }
    }
}
