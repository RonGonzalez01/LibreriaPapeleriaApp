using LibreriaPapeleriaApp.Data;
using LibreriaPapeleriaApp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(80); // Configura Kestrel para escuchar en el puerto 80
});

// Agregar la cadena de conexión
builder.Services.AddDbContext<LibreriaPapeleriaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LibreriaPapeleriaContext")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<LibreriaPapeleriaContext>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSignalR(); // Añadir SignalR a los servicios

builder.Services.AddHttpClient<ProductOrdenService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["BaseUrls:ProductosApi"]);
});

builder.Services.AddHttpClient<ProveedorService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["BaseUrls:ProveedoresApi"]);
});


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
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapHub<ChatHub>("/chathub"); // Configurar el endpoint de SignalR

app.Run();
