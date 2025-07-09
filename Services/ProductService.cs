using ProductApi.Models;
using ProductApi.Repositories;

namespace ProductApi.Services;

public class ProductService(IProductRepository repository) : IProductService
{
    public Task<List<Product>> GetAllProductsAsync() => repository.GetAllAsync();
    
    public Task<Product?> GetProductByIdAsync(long id) => repository.GetByIdAsync(id);
    
    public async Task<Product> CreateProductAsync(Product product)
    {
        if (product.Price <= 0)
            throw new ArgumentException("Price must be positive");

        return await repository.AddAsync(product);
    }
    
    public async Task UpdateProductAsync(long id, Product product)
    {
        var existing = await repository.GetByIdAsync(id) 
            ?? throw new KeyNotFoundException("Product not found");
        
        existing.Name = product.Name;
        existing.Price = product.Price;
        existing.Quantity = product.Quantity;
        
        await repository.UpdateAsync(existing);
    }
    
    public async Task DeleteProductAsync(long id)
    {
        if (await repository.GetByIdAsync(id) is { } product)
            await repository.DeleteAsync(id);
        else
            throw new KeyNotFoundException("Product not found");
    }
}