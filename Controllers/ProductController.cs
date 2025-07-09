using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
using ProductApi.Services;

namespace ProductApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IProductService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetAll() 
        => Ok(await service.GetAllProductsAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetById(long id)
        => await service.GetProductByIdAsync(id) is { } product 
            ? Ok(product) 
            : NotFound();

    [HttpPost]
    [Transactional]
    public async Task<ActionResult<Product>> Create(Product product)
    {
        var created = await service.CreateProductAsync(product);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, Product product)
    {
        await service.UpdateProductAsync(id, product);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        await service.DeleteProductAsync(id);
        return NoContent();
    }
}