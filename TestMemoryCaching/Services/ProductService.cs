using Microsoft.Extensions.Caching.Memory;
using TestMemoryCaching.Entities;

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
           return await _context.Products.OrderBy(x=>x.Name).ToListAsync(cancellation);
        }
    }
}
