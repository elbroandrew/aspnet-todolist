using ProductApi.Models;

namespace ProductApi.Services;

public interface IProductService
{
    Task<List<TodoTask>> GetAllProductsAsync();
    Task<TodoTask?> GetProductByIdAsync(long id);
    Task<TodoTask> CreateProductAsync(TodoTask todoTask);
    System.Threading.Tasks.Task UpdateProductAsync(long id, TodoTask todoTask);
    System.Threading.Tasks.Task DeleteProductAsync(long id);
}