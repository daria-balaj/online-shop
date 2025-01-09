using API.Data;
using API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Services;

public class ProductService : IProductService
{
    private readonly ProductRepository _productRepository;

    public ProductService(ProductRepository repo) 
    {
        _productRepository = repo;
    }

    public async Task<List<Product>> GetProducts()
    {
        return await this._productRepository.GetProductsAsync();
    }

    public async Task<Product?> GetProductByID(int id)
    {
        return await this._productRepository.GetProductByIdAsync(id);
    }

    public async Task<bool> CreateProduct(Product product)
    {
        return await _productRepository.CreateProductAsync(product);
    }

}