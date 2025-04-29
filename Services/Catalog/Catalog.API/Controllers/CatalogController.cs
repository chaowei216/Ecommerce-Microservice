using Catalog.Application.Commands;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

public class CatalogController : ApiController
{
    private readonly IMediator _mediator;

    public CatalogController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Endpoint for getting all products
    /// </summary>
    /// <returns>list of products</returns>
    [HttpGet(Name = "GetAllProducts")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<ProductResponse>))]
    public async Task<ActionResult<IList<ProductResponse>>> GetAllProducts()
    {
        var products = await _mediator.Send(new GetAllProductsQuery());
        return Ok(products);
    }

    /// <summary>
    /// Endpoint for getting product by id
    /// </summary>
    /// <param name="id">the id of product</param>
    /// <returns>product information</returns>
    [HttpGet("{id}", Name = "GetProductById")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductResponse>> GetProductById(string id)
    {
        var product = await _mediator.Send(new GetProductByIdQuery() { Id = id });
        return Ok(product);
    }

    /// <summary>
    /// Endpoint for getting product by name
    /// </summary>
    /// <param name="name">name of product</param>
    /// <returns>list of products</returns>
    [HttpGet("{name}", Name = "GetProductsByName")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<ProductResponse>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IList<ProductResponse>>> GetProductsByName(string name)
    {
        var products = await _mediator.Send(new GetProductByNameQuery() { Name = name });
        return Ok(products);
    }

    /// <summary>
    /// Endpoint for getting all brands
    /// </summary>
    /// <returns>list of brands</returns>
    [HttpGet("brands", Name = "GetAllBrands")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<BrandResponse>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IList<BrandResponse>>> GetAllBrands()
    {
        var brands = await _mediator.Send(new GetAllBrandsQuery());
        return Ok(brands);
    }

    /// <summary>
    /// Endpoint for getting all types
    /// </summary>
    /// <returns>list of types</returns>
    [HttpGet("types", Name = "GetAllTypes")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<TypeResponse>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IList<TypeResponse>>> GetAllTypes()
    {
        var types = await _mediator.Send(new GetAllTypesQuery());
        return Ok(types);
    }
    
    /// <summary>
    /// Endpoint for getting all types
    /// </summary>
    /// <returns>list of types</returns>
    [HttpGet("brands/{brand}", Name = "GetAllTypes")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<ProductResponse>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IList<ProductResponse>>> GetProductsByBrandName(string brand)
    {
        var brands = await _mediator.Send(new GetProductByBrandQuery() { BrandName = brand });
        return Ok(brands);
    }
    
    /// <summary>
    /// Endpoint for creating a product
    /// </summary>
    /// <param name="request">new product information request</param>
    /// <returns>new product</returns>
    [HttpPost(Name = "CreateProduct")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProductResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProductResponse>> CreateProduct([FromBody] CreateProductCommand request)
    {
        var createdProduct = await _mediator.Send(request);
        return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.Id }, createdProduct);
    }
    
    /// <summary>
    /// Endpoint for putting a product
    /// </summary>
    /// <param name="request">updated product information request</param>
    /// <returns>updated result</returns>
    [HttpPut(Name = "UpdateProduct")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<bool>> UpdateProduct([FromBody] UpdateProductCommand request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }
    
    /// <summary>
    /// Endpoint for deleting a product
    /// </summary>
    /// <param name="id">the id of product</param>
    /// <returns>deleted result</returns>
    [HttpDelete("{id}", Name = "DeleteProduct")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<bool>> UpdateProduct(string id)
    {
        var result = await _mediator.Send(new DeleteProductCommand() { Id = id });
        return Ok(result);
    }
}