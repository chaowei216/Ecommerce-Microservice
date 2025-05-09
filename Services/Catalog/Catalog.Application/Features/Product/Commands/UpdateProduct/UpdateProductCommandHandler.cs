﻿using BuildingBlocks.CQRS;
using Catalog.Application.Features.Product.Commands;
using Catalog.Application.Mappers;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Features.Product.Handlers;

public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, bool>
{
    private readonly IProductRepository _productRepository;
    
    public UpdateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetProductByIdAsync(request.Id);
        
        if (product == null)
        {
            throw new ApplicationException("Product not found.");
        }
        
        var updatedProduct = ProductMapper.Mapper.Map(request, product);
        
        var result = await _productRepository.UpdateProductAsync(updatedProduct);
        
        return result;
    }
}