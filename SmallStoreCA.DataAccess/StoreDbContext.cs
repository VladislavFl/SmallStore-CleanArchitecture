using Microsoft.EntityFrameworkCore;
using SmallStoreCA.DataAccess.Entities;

namespace SmallStoreCA.DataAccess
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {
            
        }

        public DbSet<ProductEntity> Products { get; set; }
    }
}
