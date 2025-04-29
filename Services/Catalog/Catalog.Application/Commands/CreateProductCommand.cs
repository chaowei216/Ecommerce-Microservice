using Catalog.Application.Responses;
using Catalog.Core.Entities;
using MediatR;

namespace Catalog.Application.Commands;

public class CreateProductCommand : IRequest<ProductResponse>
{
    public string Name { get; set; } = null!;

    public string Summary { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string ImageFile { get; set; } = null!;

    public decimal Price { get; set; }

    public ProductBrand Brands { get; set; }

    public ProductType Types { get; set; }
}