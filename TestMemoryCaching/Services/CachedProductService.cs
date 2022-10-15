using Microsoft.Extensions.Caching.Memory;
using TestMemoryCaching.Entities;

namespace TestMemoryCaching.Services
{
    public class CachedProductService : IProductService
    {
        private readonly IProductService _productService;
        private readonly IMemoryCache _memoryCache;
        private const string ProductListCacheKey = "productLIst";
        public CachedProductService(IProductService productService, IMemoryCache memoryCache)
        {
            _productService = productService;
            _memoryCache = memoryCache;
        }
    
        public async Task<List<Product>> GetAll(CancellationToken cancellation)
        {
            var options = new MemoryCacheEntryOptions()
                 .SetSlidingExpiration(TimeSpan.FromSeconds(10))
                 .SetAbsoluteExpiration(TimeSpan.FromSeconds(30));
            if (_memoryCache.TryGetValue(ProductListCacheKey, out List<Product> result))
                return result;
            result = await _productService.GetAll(cancellation);
            _memoryCache.Set(ProductListCacheKey, result, options);
            return result;

        }
    }
}
