using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Models;

namespace ProductApi.Repositories;

public class TodoRepository(AppDbContext context) : ITodoRepository
{
    public async Task<List<TodoTask>> GetAllAsync() => await context.TodoTasks.ToListAsync();
    
    public async Task<TodoTask?> GetByIdAsync(long id) => await context.TodoTasks.FindAsync(id);
    
    public async Task<TodoTask> AddAsync(TodoTask todoTask)
    {
        context.TodoTasks.Add(todoTask);
        await context.SaveChangesAsync();
        return todoTask;
    }
    
    public async Task UpdateAsync(TodoTask todoTask)
    {
        context.Entry(todoTask).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }
    
    public async Task DeleteAsync(long id)
    {
        var task = await GetByIdAsync(id);
        if (task != null)
        {
            context.TodoTasks.Remove(task);
            await context.SaveChangesAsync();
        }
    }
}