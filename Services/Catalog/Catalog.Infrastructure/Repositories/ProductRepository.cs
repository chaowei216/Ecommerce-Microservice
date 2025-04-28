using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories;

public class ProductRepository : IProductRepository, IBrandRepository, ITypeRepository
{
    private readonly ICatalogContext _context;
    
    public ProductRepository(ICatalogContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _context.Products
            .Find(p => true)
            .ToListAsync();
    }

    public async Task<Product?> GetProductByIdAsync(string productId)
    {
        return await _context.Products
            .Find(p => p.Id == productId)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Product>> GetProductsByNameAsync(string productName)
    {
        return await _context.Products
            .Find(p => p.Name.Contains(productName, StringComparison.CurrentCultureIgnoreCase))
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetProductsByBrandAsync(string brandName)
    {
        return await _context.Products
            .Find(p => p.Brands.Name.Contains(brandName, StringComparison.CurrentCultureIgnoreCase))
            .ToListAsync();
    }

    public async Task<Product> CreateProductAsync(Product product)
    {
        await _context.Products.InsertOneAsync(product);
        return product;
    }

    public async Task<bool> UpdateProductAsync(Product product)
    {
        var updatedProduct = await _context.Products
            .ReplaceOneAsync(p => p.Id == product.Id, product);
        
        return updatedProduct.IsAcknowledged && updatedProduct.ModifiedCount > 0;
    }

    public async Task<bool> DeleteProductAsync(string productId)
    {
        var deletedProduct = await _context.Products
            .DeleteOneAsync(p => p.Id == productId);
        
        return deletedProduct.IsAcknowledged && deletedProduct.DeletedCount > 0;
    }

    public async Task<IEnumerable<ProductBrand>> GetProductBrandsAsync()
    {
        return await _context.Brands
            .Find(b => true)
            .ToListAsync();
    }

    public async Task<IEnumerable<ProductType>> GetProductTypesAsync()
    {
        return await _context.Types
            .Find(t => true)
            .ToListAsync();
    }
}