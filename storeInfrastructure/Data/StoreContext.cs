﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using storeCore.Entities;
using storeCore.Entities.OrderAggregate;
using System;
using System.Linq;
using System.Reflection;

namespace storeInfrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext( DbContextOptions<StoreContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


           // If you are sorting and getting an error without opening this blog, please open this blog

            //if (Database.ProviderName == "Microsoft.EntityFrameworkCore.MySql")
            //{
            //    foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            //    {
            //        var properties = entityType.ClrType.GetProperties().Where(p => p.PropertyType == typeof(decimal));
            //        var dateTimeProperties = entityType.ClrType.GetProperties()
            //            .Where(p => p.PropertyType == typeof(DateTimeOffset));
            //        foreach (var property in properties)
            //        {
            //            modelBuilder.Entity(entityType.Name).Property(property.Name)
            //                .HasConversion<double>();
            //        }
            //        foreach (var property in dateTimeProperties)
            //        {
            //            modelBuilder.Entity(entityType.Name).Property(property.Name)
            //                .HasConversion(new DateTimeOffsetToBinaryConverter());
            //        }
            //    }
            //}
        }

    }
}
