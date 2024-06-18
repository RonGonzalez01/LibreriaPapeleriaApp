using LibreriaPapeleriaApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Agregar la cadena de conexión
builder.Services.AddDbContext<LibreriaPapeleriaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LibreriaPapeleriaContext")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<LibreriaPapeleriaContext>();

builder.Services.AddRazorPages();

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

app.Run();
