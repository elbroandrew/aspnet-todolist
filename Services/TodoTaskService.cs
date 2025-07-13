using ProductApi.Models;
using ProductApi.Repositories;

namespace ProductApi.Services;

public class TodoTaskService(ITodoRepository repository) : IProductService
{
    public Task<List<TodoTask>> GetAllProductsAsync() => repository.GetAllAsync();
    
    public Task<TodoTask?> GetProductByIdAsync(long id) => repository.GetByIdAsync(id);
    
    public async Task<TodoTask> CreateProductAsync(TodoTask todoTask)
    {
        return await repository.AddAsync(todoTask);
    }
    
    public async Task UpdateProductAsync(long id, TodoTask todoTask)
    {
        var existingTask = await repository.GetByIdAsync(id) 
            ?? throw new KeyNotFoundException("Product not found");
        
        existingTask.Title = todoTask.Title;
        existingTask.Completed = todoTask.Completed;
        
        await repository.UpdateAsync(existingTask);
    }
    
    public async Task DeleteProductAsync(long id)
    {
        if (await repository.GetByIdAsync(id) is { } product)
            await repository.DeleteAsync(id);
        else
            throw new KeyNotFoundException("Product not found");
    }
}