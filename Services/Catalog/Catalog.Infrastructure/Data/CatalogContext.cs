using Catalog.Core.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

public class CatalogContext : ICatalogContext
{
    public IMongoCollection<Product> Products { get; }
    public IMongoCollection<ProductBrand> Brands { get; }
    public IMongoCollection<ProductType> Types { get; }

    public CatalogContext(IConfiguration configuration)
    {
        // set up connection
        var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
        
        // mapping collection
        Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
        Brands = database.GetCollection<ProductBrand>(configuration.GetValue<string>("DatabaseSettings:BrandsCollection"));
        Types = database.GetCollection<ProductType>(configuration.GetValue<string>("DatabaseSettings:TypesCollection"));

        // seed data
        BrandContextSeed.SeedData(Brands);
        CatalogContextSeed.SeedData(Products);
        TypeContextSeed.SeedData(Types);
    }
}