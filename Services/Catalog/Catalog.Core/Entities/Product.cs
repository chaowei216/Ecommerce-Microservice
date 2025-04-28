using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Core.Entities;

public class Product : BaseEntity
{
    [BsonElement("Name")] public string Name { get; set; } = null!;

    [BsonElement("Summary")] public string Summary { get; set; } = null!;

    [BsonElement("Description")] public string Description { get; set; } = null!;

    [BsonElement("ImageFile")] public string ImageFile { get; set; } = null!;

    [BsonElement("Price")]
    [BsonRepresentation(BsonType.Decimal128)]
    public decimal Price { get; set; }

    public ProductBrand Brands { get; set; }

    public ProductType Types { get; set; }
}