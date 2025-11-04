using System;
using System.IO;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using personapi_dotnet.Models.Dao;
using personapi_dotnet.Models.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Register DbContext using connection string from configuration with retry policy
builder.Services.AddDbContext<ArqPerDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(10),
            errorNumbersToAdd: null
        )));

// Register DAOs
builder.Services.AddScoped<IPersonaDao, PersonaDao>();
builder.Services.AddScoped<IProfesionDao, ProfesionDao>();
builder.Services.AddScoped<IEstudioDao, EstudioDao>();
builder.Services.AddScoped<ITelefonoDao, TelefonoDao>();

// Swagger / OpenAPI (OpenAPI v3)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Monolith Person API",
        Version = "v1",
        Description = "API endpoints for Personas, Telefonos, Profesions and Estudios"
    });

    // Include XML comments if generated (optional)
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        options.IncludeXmlComments(xmlPath);
    }
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Serve Swagger UI and JSON (Enable on all environments; tweak as needed)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Monolith Person API v1");
    c.RoutePrefix = "swagger"; // UI at /swagger
});

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Map attribute routed API controllers

app.MapControllers();

// Keep MVC route for existing Views
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
