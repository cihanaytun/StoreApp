using Microsoft.EntityFrameworkCore;
using storeCore.Entities;
using System.Linq;
using System.Reflection;

namespace storeInfrastructure.Data
{
    /// <summary>
    /// Database
    /// </summary>
    public class StoreContext : DbContext
    {
        public StoreContext( DbContextOptions<StoreContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            // If you are sorting and getting an error without opening this blog, please open this blog

            //if (Database.ProviderName =="Microsoft.EntityFrameworkCore.MySql")
            //{
            //    foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            //    {
            //        var properties = entityType.ClrType.GetProperties().Where(p => p.PropertyType == typeof(decimal));
            //        foreach (var property in properties)
            //        {
            //            modelBuilder.Entity(entityType.Name).Property(property.Name)
            //                .HasConversion<double>();
            //        }
            //    }
            //}
        }

    }
}
