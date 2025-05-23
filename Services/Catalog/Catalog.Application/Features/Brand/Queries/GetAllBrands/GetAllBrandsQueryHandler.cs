﻿using BuildingBlocks.CQRS;
using Catalog.Application.DTOs;
using Catalog.Application.Mappers;
using Catalog.Core.Repositories;

namespace Catalog.Application.Features.Brand.Queries.GetAllBrands;

public class GetAllBrandsQueryHandler : IQueryHandler<GetAllBrandsQuery, IList<BrandResponse>>
{
    private readonly IBrandRepository _brandRepository;

    public GetAllBrandsQueryHandler(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }
    
    public async Task<IList<BrandResponse>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
    {
        var brandList = await _brandRepository.GetProductBrandsAsync();
        
        var response = ProductMapper.Mapper.Map<IList<BrandResponse>>(brandList);
        
        return response;
    }
}