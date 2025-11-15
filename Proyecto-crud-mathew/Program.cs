using Microsoft.EntityFrameworkCore;
using ProyectoCrudMathew.Data;
using Microsoft.Extensions.DependencyInjection;
using Proyecto_crud_mathew.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Proyecto_crud_mathewContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Proyecto_crud_mathewContext") ?? throw new InvalidOperationException("Connection string 'Proyecto_crud_mathewContext' not found.")));

// Agregar DbContext + conexi�n
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseRouting();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
