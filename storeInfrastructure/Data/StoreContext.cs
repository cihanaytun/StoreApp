using Microsoft.EntityFrameworkCore;
using storeCore.Entities;

namespace storeInfrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext( DbContextOptions<StoreContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }

    }
}
