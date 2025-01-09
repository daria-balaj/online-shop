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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProductCatalog()
    {
        Console.WriteLine("hello from products endpoint");
        var catalog = await _repository.GetProductsAsync();
        if (catalog == null) return NotFound("Product catalog empty");
        return Ok(catalog);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProductByID([FromQuery] int id)
    {
        var result = await _repository.GetProductByIdAsync(id);
        if (result != null) return Ok(result);
        return NotFound(null);
    }
}