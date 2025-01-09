

using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class ProductRepository
{
    private readonly DataContext _context;
    public ProductRepository(DataContext context) 
    {
        _context = context;
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<bool> CreateProductAsync(Product product)
    {
        _context.Add(product);
        return await _context.SaveChangesAsync() > 0;

    }
}