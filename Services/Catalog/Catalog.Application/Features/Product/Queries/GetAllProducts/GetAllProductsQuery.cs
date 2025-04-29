using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Features.Product.Queries.GetAllProducts;

public class GetAllProductsQuery : IRequest<IList<ProductResponse>>
{
    
}