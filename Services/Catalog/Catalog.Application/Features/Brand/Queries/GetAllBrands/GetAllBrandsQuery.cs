using BuildingBlocks.CQRS;
using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Features.Brand.Queries.GetAllBrands;

public class GetAllBrandsQuery : IQuery<IList<BrandResponse>>
{
    
}