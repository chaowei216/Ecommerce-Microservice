using BuildingBlocks.CQRS;
using Catalog.Application.DTOs;
using Catalog.Core.Entities;

namespace Catalog.Application.Features.Product.Commands.CreateProduct;

public class CreateProductCommand : ICommand<ProductResponse>
{
    public string Name { get; set; } = null!;

    public string Summary { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string ImageFile { get; set; } = null!;

    public decimal Price { get; set; }

    public ProductBrand Brands { get; set; }

    public ProductType Types { get; set; }
}