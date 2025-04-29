using System.Text.Json;
using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

public static class BrandContextSeed
{
    public static async Task SeedData(IMongoCollection<ProductBrand> brandCollection)
    {
        bool checkBrands = brandCollection.Find(p => true).Any();
        // string path = Path.Combine("Data", "SeedData", "brands.json");
        
        if (!checkBrands)
        {
            var brandsData = await File.ReadAllTextAsync("../Catalog.Infrastructure/Data/SeedData/brands.json");
            var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

            if (brands != null)
            {
                foreach (var brand in brands)
                {
                    await brandCollection.InsertOneAsync(brand);
                }
            }
        }
    }
}