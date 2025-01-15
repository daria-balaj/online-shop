

using API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
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

    public async Task<Product[]> SearchProductsAsync(string term)
    {
        return await _context.Products.Where(p => p.Title.ToLower().Contains(term.ToLower())).ToArrayAsync();
    }

    public async Task DeleteProductAsync(int id)
    {
        Product? p = await _context.Products.FindAsync(id);
        if (p != null) 
        {
            _context.Remove(p);
            await _context.SaveChangesAsync();
        }
    }
}