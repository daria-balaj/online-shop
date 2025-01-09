using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Services;

public interface IProductService
{
    public Task<List<Product>> GetProducts();
    public Task<Product> GetProductByID(int id);
    public Task<bool> CreateProduct(Product product);

}