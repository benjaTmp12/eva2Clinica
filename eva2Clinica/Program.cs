using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Configuración de Cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Index";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    });

// Inyección de dependencias de tu base de datos
builder.Services.AddSingleton<eva2Clinica.Models.ConexionBD>();
builder.Services.AddScoped<eva2Clinica.Models.PacienteData>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseRouting();

// Seguridad en el orden correcto
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

// Ruta por defecto al Home
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();