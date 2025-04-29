using BuildingBlocks.CQRS;
using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Features.Product.Queries;

public class GetProductByIdQuery : IQuery<ProductResponse>
{
    public string Id { get; set; } = null!;
}