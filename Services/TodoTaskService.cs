using ProductApi.Models;
using ProductApi.Repositories;

namespace ProductApi.Services;

public class TodoTaskService(ITodoRepository repository) : ITodoTaskService
{
    public Task<List<TodoTask>> GetAllTasksAsync() => repository.GetAllAsync();
    
    public Task<TodoTask?> GetTaskByIdAsync(long id) => repository.GetByIdAsync(id);
    
    public async Task<TodoTask> CreateTaskAsync(TodoTask todoTask)
    {
        return await repository.AddAsync(todoTask);
    }
    
    public async Task UpdateTaskAsync(long id, TodoTask todoTask)
    {
        var existingTask = await repository.GetByIdAsync(id) 
            ?? throw new KeyNotFoundException("Task not found");
        
        existingTask.Title = todoTask.Title;
        existingTask.Completed = todoTask.Completed;
        
        await repository.UpdateAsync(existingTask);
    }
    
    public async Task DeleteTaskAsync(long id)
    {
        if (await repository.GetByIdAsync(id) is { } product)
            await repository.DeleteAsync(id);
        else
            throw new KeyNotFoundException("Task not found");
    }
}