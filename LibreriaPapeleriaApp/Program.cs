using LibreriaPapeleriaApp.Data;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Agregar la cadena de conexi�n
builder.Services.AddDbContext<LibreriaPapeleriaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LibreriaPapeleriaContext")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<LibreriaPapeleriaContext>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSignalR(); // A�adir SignalR a los servicios

var app = builder.Build();

// Configuraci�n restante del pipeline
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
app.MapControllers(); // A�adir esto si no est� ya presente
app.MapHub<ChatHub>("/chathub"); // Configurar el endpoint de SignalR

app.Run();
