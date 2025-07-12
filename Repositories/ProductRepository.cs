using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Models;

namespace ProductApi.Repositories;

public class ProductRepository(AppDbContext db) : IProductRepository
{
    public async Task<List<TodoTask>> GetAllAsync() => await db.Products.ToListAsync();
    
    public async Task<TodoTask?> GetByIdAsync(long id) => await db.Products.FindAsync(id);
    
    public async Task<TodoTask> AddAsync(TodoTask todoTask)
    {
        db.Products.Add(todoTask);
        await db.SaveChangesAsync();
        return todoTask;
    }
    
    public async System.Threading.Tasks.Task UpdateAsync(TodoTask todoTask)
    {
        db.Entry(todoTask).State = EntityState.Modified;
        await db.SaveChangesAsync();
    }
    
    public async System.Threading.Tasks.Task DeleteAsync(long id)
    {
        var product = await GetByIdAsync(id);
        if (product != null)
        {
            db.Products.Remove(product);
            await db.SaveChangesAsync();
        }
    }
}