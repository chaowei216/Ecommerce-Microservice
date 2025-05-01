using BuildingBlocks.CQRS;
using Catalog.Application.DTOs;

namespace Catalog.Application.Features.Product.Queries.GetProductById;

public class GetProductByIdQuery : IQuery<ProductResponse>
{
    public string Id { get; set; } = null!;
}