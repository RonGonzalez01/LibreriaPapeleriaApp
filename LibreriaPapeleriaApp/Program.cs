using LibreriaPapeleriaApp.Data;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Agregar la cadena de conexión
builder.Services.AddDbContext<LibreriaPapeleriaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LibreriaPapeleriaContext")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<LibreriaPapeleriaContext>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSignalR(); // Añadir SignalR a los servicios

var app = builder.Build();

// Configuración restante del pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers(); // Añadir esto si no está ya presente
app.MapHub<ChatHub>("/chathub"); // Configurar el endpoint de SignalR

app.Run();
