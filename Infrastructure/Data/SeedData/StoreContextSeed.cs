using System.Text.Json;
using Microsoft.Extensions.Logging;

public class StoreContextSeed {

    public static async Task SeedStoreContext(SkinetContext skinetContext, ILoggerFactory loggerFactory) {
        
        try {

            if (!skinetContext.ProductTypes.Any()) {
                var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                var productTypes = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                foreach(var productType in productTypes) {
                    skinetContext.ProductTypes.Add(productType);
                }
                skinetContext.SaveChanges();
            }

            if (!skinetContext.ProductBrands.Any()) {
                var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");

                List<ProductBrand> brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                foreach(var brand in brands) {
                    skinetContext.ProductBrands.Add(brand);
                }
                skinetContext.SaveChanges(); 
            }

            if (!skinetContext.Products.Any()) {
                var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                var products =  JsonSerializer.Deserialize<List<Product>>(productsData);
                
                foreach(var product in products) {
                    skinetContext.Products.Add(product);
                }

                skinetContext.SaveChanges();   
            }
        }
        catch (Exception ex) {
            var logger = loggerFactory.CreateLogger("StoreContextSeed");
            logger.LogError($"An error occure while Seeding data: {ex.Message}");
        }
    }
}