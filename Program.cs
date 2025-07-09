using Microsoft.EntityFrameworkCore;
using ProductApi.Controllers;
using ProductApi.Data;
using ProductApi.Models;
using ProductApi.Repositories;
using ProductApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Добавляем необходимые сервисы
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddControllers();

// Добавляем Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Product API", Version = "v1" });
});

var app = builder.Build();

// Настраиваем конвейер middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => 
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product API V1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Инициализация БД
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
    
    if (!db.Products.Any())
    {
        db.Products.AddRange(
            new Product { Name = "Laptop", Price = 999.99, Quantity = 10 },
            new Product { Name = "Phone", Price = 699.99, Quantity = 20 }
        );
        await db.SaveChangesAsync();
    }
}

app.Run();