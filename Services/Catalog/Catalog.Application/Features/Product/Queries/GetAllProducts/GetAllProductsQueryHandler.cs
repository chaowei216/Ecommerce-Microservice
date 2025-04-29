using BuildingBlocks.CQRS;
using Catalog.Application.Features.Product.Queries.GetAllProducts;
using Catalog.Application.Mappers;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;

namespace Catalog.Application.Features.Product.Handlers;

public class GetAllProductsQueryHandler : IQueryHandler<GetAllProductsQuery, IList<ProductResponse>>
{
    private readonly IProductRepository _productRepository;
    
    public GetAllProductsQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    public async Task<IList<ProductResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var productList = await _productRepository.GetAllProductsAsync();
        
        var response = ProductMapper.Mapper.Map<IList<ProductResponse>>(productList);
        
        return response;
    }
}