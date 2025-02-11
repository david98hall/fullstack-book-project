using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Backend.Data;
using Backend.Model;

var builder = WebApplication.CreateBuilder(args);

// Add BookContext to container services so that it can be used for dependency injection in the MVC controller
builder.Services.AddDbContext<BookContext>(
    options => options.UseNpgsql(Environment.GetEnvironmentVariable("DbConnectionString")));

// Add the MVC controller (initialized with the BookContext via ASP.NET's dependency injection feature)
builder.Services.AddControllers();

// Define the Cross-Origin Resource Sharing (CORS) policy
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        // Specify the allowed origin for cross-origin requests
        builder.WithOrigins("http://localhost:1234")
               .AllowAnyHeader() // Allow any HTTP header
               .AllowAnyMethod(); // Allow any HTTP method (GET, POST, PUT, etc)
    });
});

var app = builder.Build();

// The web browser blocks the frontend from fetching data from the backend.
// This resolves that issue by allowing cross-origin resource sharing
// (CORS) requests from the frontend.
app.UseCors();

// Map controllers to correctly route HTTP requests to MVC controller
app.MapControllers();

// Run the ASP.NET application and configure it to listen for
// HTTP requests on all network interfaces at the specified port
app.Run($"http://*:{Environment.GetEnvironmentVariable("BackendPort")}");