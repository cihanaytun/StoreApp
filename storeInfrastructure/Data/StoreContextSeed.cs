using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using storeCore.Entities;

namespace storeInfrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext storeContext ,ILoggerFactory loggerFactory)
        {
            try
            {
                //ProductBrand
             
                if (!storeContext.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText("../storeInfrastructure/Data/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                    //üstteki veriyi ayrıştırıp productbrand a attık
                    foreach (var item in brands)
                    {
                        storeContext.ProductBrands.Add(item);
                    }
                    await storeContext.SaveChangesAsync();
                }

                //ProductType
                if (!storeContext.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText("../storeInfrastructure/Data/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                    //üstteki veriyi ayrıştırıp producttype a attık
                    foreach (var item in types)
                    {
                        storeContext.ProductTypes.Add(item);
                    }
                    await storeContext.SaveChangesAsync();
                }

                //Product
                if (!storeContext.Products.Any())
                {
                    var productsData = File.ReadAllText("../storeInfrastructure/Data/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                    //üstteki veriyi ayrıştırıp product a attık
                    foreach (var item in products)
                    {
                        storeContext.Products.Add(item);
                    }
                    await storeContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
