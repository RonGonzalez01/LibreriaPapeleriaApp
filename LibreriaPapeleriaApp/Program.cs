using LibreriaPapeleriaApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Agregar la cadena de conexi�n
builder.Services.AddDbContext<LibreriaPapeleriaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LibreriaPapeleriaContext")));

builder.Services.AddRazorPages();

var app = builder.Build();

// Configuraci�n restante del pipeline
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
});

app.Run();
