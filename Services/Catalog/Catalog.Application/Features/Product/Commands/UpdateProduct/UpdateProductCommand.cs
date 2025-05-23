﻿using BuildingBlocks.CQRS;
using Catalog.Core.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Application.Features.Product.Commands;

public class UpdateProductCommand : ICommand<bool>
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