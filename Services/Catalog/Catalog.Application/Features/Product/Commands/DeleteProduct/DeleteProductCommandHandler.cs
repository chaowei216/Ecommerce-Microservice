using Catalog.Application.Features.Product.Commands;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Features.Product.Handlers;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IProductRepository _productRepository;
    
    public DeleteProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetProductByIdAsync(request.Id);
        
        if (product == null)
        {
            throw new ApplicationException("Product not found.");
        }
        
        var result = await _productRepository.DeleteProductAsync(product.Id);
        
        return result;
    }
}