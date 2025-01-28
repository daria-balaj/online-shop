using System.Text.Json;
using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace Tests;

public class TestDbContext : DbContext
{
    public TestDbContext(DbContextOptions<TestDbContext> options) : base( options ) {}

    public static async Task SeedTestData(DataContext context)
    {
        var data = await File.ReadAllTextAsync(@"C:\Users\daria\source\repos\eShop\ShopApiTest\testdata.json");
        var serializerOptions = new JsonSerializerOptions{ PropertyNameCaseInsensitive = true };

        var users = JsonSerializer.Deserialize<IEnumerable<User>>(data, serializerOptions);
        if (users != null)
        {
            foreach(var user in users)
            {
                context.Add(user);
            } 
            await context.SaveChangesAsync();
        }
    }

}

public class TestDbContextFactory
{
}