using Microsoft.EntityFrameworkCore;
using ProductApi.Models;

namespace ProductApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<TodoTask> TodoTasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(u => u.Username).IsRequired();
            entity.Property(u => u.Email).IsRequired();
        });

        modelBuilder.Entity<TodoTask>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(t => t.Title).IsRequired();
            entity.Property(t => t.Completed).IsRequired();
        });
    }
}