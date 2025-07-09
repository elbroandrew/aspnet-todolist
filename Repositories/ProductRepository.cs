using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Models;

namespace ProductApi.Repositories;

public class ProductRepository(AppDbContext db) : IProductRepository
{
    public async Task<List<Product>> GetAllAsync() => await db.Products.ToListAsync();
    
    public async Task<Product?> GetByIdAsync(long id) => await db.Products.FindAsync(id);
    
    public async Task<Product> AddAsync(Product product)
    {
        db.Products.Add(product);
        await db.SaveChangesAsync();
        return product;
    }
    
    public async Task UpdateAsync(Product product)
    {
        db.Entry(product).State = EntityState.Modified;
        await db.SaveChangesAsync();
    }
    
    public async Task DeleteAsync(long id)
    {
        var product = await GetByIdAsync(id);
        if (product != null)
        {
            db.Products.Remove(product);
            await db.SaveChangesAsync();
        }
    }
}