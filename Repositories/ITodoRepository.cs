using ProductApi.Models;

namespace ProductApi.Repositories;

public interface ITodoRepository
{
    Task<List<TodoTask>> GetAllAsync();
    Task<TodoTask?> GetByIdAsync(long id);
    Task<TodoTask> AddAsync(TodoTask todoTask);
    Task UpdateAsync(TodoTask todoTask);
    Task DeleteAsync(long id);
}