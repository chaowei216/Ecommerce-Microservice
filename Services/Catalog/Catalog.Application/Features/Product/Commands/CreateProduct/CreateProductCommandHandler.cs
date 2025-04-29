using Catalog.Application.Mappers;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Features.Product.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductResponse>
{
    private readonly IProductRepository _productRepository;
    
    public CreateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        // Map the command to the entity
        var product = ProductMapper.Mapper.Map<Core.Entities.Product>(request);

        if (product is null)
        {
            throw new ApplicationException("There is an issue with the product mapping.");
        }
        
        // Save the product to the repository
        var createdProduct = await _productRepository.CreateProductAsync(product);
        
        // Map the created product to the response
        var response = ProductMapper.Mapper.Map<ProductResponse>(createdProduct);
        
        return response;
    }
}