using BuildingBlocks.CQRS;
using Catalog.Application.DTOs;
using Catalog.Application.Features.Product.Queries;
using Catalog.Application.Mappers;
using Catalog.Core.Repositories;

namespace Catalog.Application.Features.Product.Queries.GetProductById;

public class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, ProductResponse>
{
    private readonly IProductRepository _productRepository;
    
    public GetProductByIdQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    public async Task<ProductResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetProductByIdAsync(request.Id);
        
        if (product == null)
        {
            return null!;
        }

        var response = ProductMapper.Mapper.Map<ProductResponse>(product);
        
        return response;
    }
}