using BuildingBlocks.CQRS;
using MediatR;

namespace Catalog.Application.Features.Product.Commands;

public class DeleteProductCommand : ICommand<bool>
{
    public string Id { get; set; } = null!;
}