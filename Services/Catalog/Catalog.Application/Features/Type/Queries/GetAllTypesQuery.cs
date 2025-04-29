using BuildingBlocks.CQRS;
using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Features.Type.Queries.GetAllTypes;

public class GetAllTypesQuery : IQuery<IList<TypeResponse>>
{
    
}