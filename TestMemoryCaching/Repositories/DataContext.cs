using Microsoft.EntityFrameworkCore;
using TestMemoryCaching.Entities;

namespace TestMemoryCaching.Repositories
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }
        public DbSet<Product> Product { get; set; }
    }
 
}
