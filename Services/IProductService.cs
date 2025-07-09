using ProductApi.Models;

namespace ProductApi.Services;

public interface IProductService
{
    Task<List<Product>> GetAllProductsAsync();
    Task<Product?> GetProductByIdAsync(long id);
    Task<Product> CreateProductAsync(Product product);
    Task UpdateProductAsync(long id, Product product);
    Task DeleteProductAsync(long id);
}