using System.Text.Json;
using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

public static class TypeContextSeed
{
    public static async Task SeedData(IMongoCollection<ProductType> typeCollection)
    {
        bool checkTypes = typeCollection.Find(p => true).Any();
        // string path = Path.Combine("Data", "SeedData", "types.json");
        
        if (!checkTypes)
        {
            var typesData = await File.ReadAllTextAsync("../Catalog.Infrastructure/Data/SeedData/types.json");
            var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

            if (types != null)
            {
                foreach (var type in types)
                {
                    await typeCollection.InsertOneAsync(type);
                }
            }
        }
    }
}