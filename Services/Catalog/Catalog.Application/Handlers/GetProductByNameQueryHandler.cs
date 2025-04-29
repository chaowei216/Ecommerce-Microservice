﻿using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers;

public class GetProductByNameQueryHandler : IRequestHandler<GetProductByNameQuery, IList<ProductResponse>>
{
    private readonly IProductRepository _productRepository;
    
    public GetProductByNameQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    public async Task<IList<ProductResponse>> Handle(GetProductByNameQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetProductsByNameAsync(request.Name);
        
        var response = ProductMapper.Mapper.Map<IList<ProductResponse>>(products);
        
        return response;
    }
}