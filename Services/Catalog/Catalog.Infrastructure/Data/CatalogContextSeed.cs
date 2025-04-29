using System.Text.Json;
using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

public static class CatalogContextSeed
{
    public static async Task SeedData(IMongoCollection<Product> productCollection)
    {
        bool checkProducts = productCollection.Find(p => true).Any();
        // string path = Path.Combine("Data", "SeedData", "products.json");
        
        if (!checkProducts)
        {
            var productsData = await File.ReadAllTextAsync("../Catalog.Infrastructure/Data/SeedData/products.json");
            var products = JsonSerializer.Deserialize<List<Product>>(productsData);

            if (products != null)
            {
                foreach (var product in products)
                {
                    await productCollection.InsertOneAsync(product);
                }
            }
        }
    }
}