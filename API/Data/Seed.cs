using API.Models;
using System.Text.Json;

namespace API.Data;

public class Seed 
{
    public static async void SeedProducts(ProductRepository repository)
    {
        // var content = await repository.GetProductsAsync();
        // if (content.Count > 0) return;

        var data = await File.ReadAllTextAsync("Data/Catalog.json");
        var serializerOptions = new JsonSerializerOptions{ PropertyNameCaseInsensitive = true };

        var products = JsonSerializer.Deserialize<List<Product>>(data, serializerOptions);
        if (products != null)
        {
            foreach(var product in products)
            {
                await repository.CreateProductAsync(product);
            }   
        }
    }
}