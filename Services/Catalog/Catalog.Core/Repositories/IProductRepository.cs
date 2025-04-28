using Catalog.Core.Entities;

namespace Catalog.Core.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<Product?> GetProductByIdAsync(string productId);
    Task<IEnumerable<Product>> GetProductsByNameAsync(string productName);
    Task<IEnumerable<Product>> GetProductsByBrandAsync(string brandName);
    Task<Product> CreateProductAsync(Product product);
    Task<bool> UpdateProductAsync(Product product);
    Task<bool> DeleteProductAsync(string productId);
}