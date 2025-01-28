// using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddCors();

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(opt => 
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ProductRepository>();

builder.Services.AddAuthentication();


var app = builder.Build();

app.UseAuthorization();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors(policyBuilder => policyBuilder
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
        .WithOrigins("https://localhost:4200", "http://localhost:4200"));


app.MapControllers();
// app.MapFallbackToController("Index", "Fallback");

using var scope = app.Services.CreateScope();
try 
{
    var productRepo = scope.ServiceProvider.GetService<ProductRepository>();
    if (productRepo != null)
        Seed.SeedProducts(productRepo);
}
catch (Exception e) {
    Console.WriteLine(e);
}

app.Run();

public partial class Program {}