using ProductApi.Models;
using ProductApi.Repositories;

namespace ProductApi.Services;

public class ProductService(IProductRepository repository) : IProductService
{
    public Task<List<TodoTask>> GetAllProductsAsync() => repository.GetAllAsync();
    
    public Task<TodoTask?> GetProductByIdAsync(long id) => repository.GetByIdAsync(id);
    
    public async Task<TodoTask> CreateProductAsync(TodoTask todoTask)
    {
        if (todoTask.Price <= 0)
            throw new ArgumentException("Price must be positive");

        return await repository.AddAsync(todoTask);
    }
    
    public async System.Threading.Tasks.Task UpdateProductAsync(long id, TodoTask todoTask)
    {
        var existing = await repository.GetByIdAsync(id) 
            ?? throw new KeyNotFoundException("Product not found");
        
        existing.Name = todoTask.Name;
        existing.Price = todoTask.Price;
        existing.Quantity = todoTask.Quantity;
        
        await repository.UpdateAsync(existing);
    }
    
    public async System.Threading.Tasks.Task DeleteProductAsync(long id)
    {
        if (await repository.GetByIdAsync(id) is { } product)
            await repository.DeleteAsync(id);
        else
            throw new KeyNotFoundException("Product not found");
    }
}