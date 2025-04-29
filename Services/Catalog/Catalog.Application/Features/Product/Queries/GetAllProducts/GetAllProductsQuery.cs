using BuildingBlocks.CQRS;
using Catalog.Application.Responses;

namespace Catalog.Application.Features.Product.Queries.GetAllProducts;

public class GetAllProductsQuery : IQuery<IList<ProductResponse>>
{
    
}