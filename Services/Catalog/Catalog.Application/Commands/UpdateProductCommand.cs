using Catalog.Core.Entities;
using MediatR;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Application.Commands;

public class UpdateProductCommand : IRequest<bool>
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;
    
    [BsonElement("Name")]
    public string Name { get; set; } = null!;

    public string Summary { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string ImageFile { get; set; } = null!;

    public decimal Price { get; set; }

    public ProductBrand Brands { get; set; }

    public ProductType Types { get; set; }
}