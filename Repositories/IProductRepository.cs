using ProductApi.Models;

namespace ProductApi.Repositories;

public interface IProductRepository
{
    Task<List<TodoTask>> GetAllAsync();
    Task<TodoTask?> GetByIdAsync(long id);
    Task<TodoTask> AddAsync(TodoTask todoTask);
    System.Threading.Tasks.Task UpdateAsync(TodoTask todoTask);
    System.Threading.Tasks.Task DeleteAsync(long id);
}