using Microsoft.AspNetCore.Mvc;
using ProductApi.Attributes;
using ProductApi.Models;
using ProductApi.Services;

namespace ProductApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IProductService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<TodoTask>>> GetAll() 
        => Ok(await service.GetAllProductsAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<TodoTask>> GetById(long id)
        => await service.GetProductByIdAsync(id) is { } product 
            ? Ok(product) 
            : NotFound();

    [HttpPost]
    [Transactional]
    public async Task<ActionResult<TodoTask>> Create(TodoTask todoTask)
    {
        var created = await service.CreateProductAsync(todoTask);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, TodoTask todoTask)
    {
        await service.UpdateProductAsync(id, todoTask);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        await service.DeleteProductAsync(id);
        return NoContent();
    }
}