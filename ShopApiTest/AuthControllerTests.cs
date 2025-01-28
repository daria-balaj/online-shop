using API.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using API.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Net.Http.Json;

namespace Tests;

public class AuthControllerTests: IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly HttpClient _client;
    public AuthControllerTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<DataContext>));
                if (descriptor != null)
                    services.Remove(descriptor);

                services.AddDbContext<DataContext>(options =>
                    options.UseSqlite("Data source=:memory:"));
                

                var serviceProvider = services.BuildServiceProvider();

                using (var scope = serviceProvider.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<DataContext>();

                    db.Database.EnsureCreated();
                    TestDbContext.SeedTestData(db).Wait();
                }
                
            });
        });
        _client = _factory.CreateClient();
    }

    [Fact]
    public async Task Register_WithValidData_ReturnsOk()
    {
        // Arrange
        var registerDto = new RegisterDTO
        {
            Email = "test@example.com",
            Password = "Test123!",
            FirstName = "Test",
            LastName = "User"
        };

        // Act
        var response = await _client.PostAsJsonAsync("register", registerDto);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Login_WithValidCredentials_ReturnsTokens()
    {
        // Arrange
        await Register_WithValidData_ReturnsOk();
        var loginDto = new LoginDTO
        {
            Email = "test@example.com",
            Password = "Test123!"
        };

        // Act
        var response = await _client.PostAsJsonAsync("login", loginDto);
        var tokenDto = await response.Content.ReadFromJsonAsync<TokenDTO>();

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(tokenDto?.AccessToken);
        Assert.NotNull(tokenDto?.RefreshToken);
    }

    [Fact]
    public async Task Login_WithInvalidCredentials_ReturnsBadRequest()
    {
        // Arrange
        var loginDto = new LoginDTO
        {
            Email = "wrong@example.com",
            Password = "WrongPass123!"
        };

        // Act
        var response = await _client.PostAsJsonAsync("login", loginDto);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Register_WithExistingEmail_ReturnsBadRequest()
    {
        // Arrange
        await Register_WithValidData_ReturnsOk();
        var registerDto = new RegisterDTO
        {
            Email = "test@example.com",
            Password = "Test123!",
            FirstName = "Test",
            LastName = "User"
        };

        // Act
        var response = await _client.PostAsJsonAsync("register", registerDto);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}
