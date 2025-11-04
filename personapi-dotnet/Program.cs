using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Dao;
using personapi_dotnet.Models.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register DbContext using connection string from configuration
builder.Services.AddDbContext<ArqPerDbContext>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register DAOs
builder.Services.AddScoped<IPersonaDao, PersonaDao>();
builder.Services.AddScoped<IProfesionDao, ProfesionDao>();
builder.Services.AddScoped<IEstudioDao, EstudioDao>();
builder.Services.AddScoped<ITelefonoDao, TelefonoDao>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
 app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
 name: "default",
 pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
