using ProductApi.Models;

namespace ProductApi.Services;

public interface ITodoTaskService
{
    Task<List<TodoTask>> GetAllTasksAsync();
    Task<TodoTask?> GetTaskByIdAsync(long id);
    Task<TodoTask> CreateTaskAsync(TodoTask todoTask);
    Task UpdateTaskAsync(long id, TodoTask todoTask);
    Task DeleteTaskAsync(long id);
}