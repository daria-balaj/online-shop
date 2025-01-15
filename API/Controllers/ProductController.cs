using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("products")]
public class ProductController : ControllerBase
{
    // private readonly ProductService _productService;
    private readonly ProductRepository _repository;
    public ProductController(ProductRepository repository)
    {
        // _productService = productService;
        _repository = repository;
    }

    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<Product>>> GetProductCatalog()
    {
        // var catalog = await _repository.GetProductsAsync();
        // if (catalog.Count == 0) return NotFound("Product catalog empty");
        // return Ok(catalog);
        return await _repository.GetProductsAsync();

    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProductByID(int id)
    {        var result = await _repository.GetProductByIdAsync(id);
        if (result != null) return Ok(result);
        return NotFound(null);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> SearchProducts([FromQuery(Name="q")] string? term) 
    {
        Console.WriteLine(term);
        if (string.IsNullOrEmpty(term))
            return await _repository.GetProductsAsync();
        else
        {
            var result = await _repository.SearchProductsAsync(term);
            return Ok(result);
        }
    }

    [HttpDelete("delete/{id}")]
    public async void DeleteProduct([FromRoute] int id) {
        Console.WriteLine(id);
        await _repository.DeleteProductAsync(id);
    }
}