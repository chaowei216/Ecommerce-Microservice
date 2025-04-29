using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Features.Product.Queries;

public class GetProductByIdQuery : IRequest<ProductResponse>
{
    public string Id { get; set; } = null!;
}