using MediatR;

namespace Catalog.Application.Features.Product.Commands;

public class DeleteProductCommand : IRequest<bool>
{
    public string Id { get; set; } = null!;
}