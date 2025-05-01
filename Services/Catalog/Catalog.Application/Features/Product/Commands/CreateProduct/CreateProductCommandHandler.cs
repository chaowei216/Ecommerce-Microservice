using BuildingBlocks.CQRS;
using Catalog.Application.DTOs;
using Catalog.Application.Mappers;
using Catalog.Core.Repositories;
using FluentValidation;

namespace Catalog.Application.Features.Product.Commands.CreateProduct;

public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, ProductResponse>
{
    private readonly IProductRepository _productRepository;
    private readonly IValidator<CreateProductCommand> _validator;

    public CreateProductCommandHandler(IProductRepository productRepository,
        IValidator<CreateProductCommand> validator)
    {
        _productRepository = productRepository;
        _validator = validator;
    }
    
    public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        // validate
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        
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