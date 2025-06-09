using Microsoft.EntityFrameworkCore;
using Reportes.Data; // Asegúrate de que este namespace es correcto

var builder = WebApplication.CreateBuilder(args);

// ✅ REGISTRAR SERVICIOS PRIMERO (antes del Build)
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BDContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("MiConexion"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MiConexion"))
    ));

// ✅ Luego construir la app
var app = builder.Build();

// Configuración del pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}"); // Cambiado para que arranque en Login

app.Run();
