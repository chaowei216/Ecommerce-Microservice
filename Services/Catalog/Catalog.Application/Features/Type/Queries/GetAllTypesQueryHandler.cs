using BuildingBlocks.CQRS;
using Catalog.Application.Mappers;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Features.Type.Queries.GetAllTypes;

public class GetAllTypesQueryHandler : IQueryHandler<GetAllTypesQuery, IList<TypeResponse>>
{
    private readonly ITypeRepository _typeRepository;
    
    public GetAllTypesQueryHandler(ITypeRepository typeRepository)
    {
        _typeRepository = typeRepository;
    }
    
    public async Task<IList<TypeResponse>> Handle(GetAllTypesQuery request, CancellationToken cancellationToken)
    {
        var typeList = await _typeRepository.GetProductTypesAsync();
        
        var response = ProductMapper.Mapper.Map<IList<TypeResponse>>(typeList);
        
        return response;
    }
}