using ProductApi.Models;

namespace ProductApi.Repositories;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(long id);
    Task<Product> AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(long id);
}