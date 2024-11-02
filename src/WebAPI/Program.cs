using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Data;
using Core.Interfaces;
using Application.Interfaces;
using Application.Services;
using Application.Mappings;


// WebAPI/Program.cs (or Startup.cs depending on .NET version)
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging();
builder.Services.AddControllers(); // Add support for controllers

// Add services to the container
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 27))));

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

// Configure Swagger for API documentation
builder.Services.AddEndpointsApiExplorer(); // Required for endpoint discovery
builder.Services.AddSwaggerGen(); // Adds Swagger generation services

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => // Configures the Swagger UI
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); // The Swagger JSON endpoint
    c.RoutePrefix = string.Empty; // Makes Swagger UI the root of the application
});


app.UseMiddleware<ExceptionMiddleware>(); // Register the custom exception middleware


// app.UseHttpsRedirection(); // Redirect HTTP to HTTPS
// app.UseAuthorization(); // Use authorization middleware
app.MapControllers(); // Map attribute-based routes

app.Run();
