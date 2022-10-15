using TestMemoryCaching.Entities;

namespace TestMemoryCaching.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAll(CancellationToken cancellation);
    }
}
