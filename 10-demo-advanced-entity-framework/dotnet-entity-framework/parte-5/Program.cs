using Cf.Dotnet.EntityFramework.Parte5;
using Microsoft.EntityFrameworkCore;

// Inicia la construcción de una aplicación web ASP.NET Core.
var builder = WebApplication.CreateBuilder(args);

// Define una constante para el nombre de la base de datos que se usará en la cadena de conexión.
const string databaseName = "MyDatabaseName";

// Registra Razor Pages en el contenedor de servicios para habilitar el soporte de páginas Razor.
builder.Services.AddRazorPages();

// Configura el contexto de Entity Framework para utilizar SQL Server.
// La cadena de conexión se configura para conectar a una instancia de SQL Server local.
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(
        // ADVERTENCIA: la cadena de conexión no debe usarse en entornos de producción.
        $"Data Source=localhost,1433;User ID=sa;Password=Passw@rd;Database={databaseName};Encrypt=False"));

// Construye la aplicación web.
var app = builder.Build();

// Configura el pipeline de solicitudes HTTP.
if (!app.Environment.IsDevelopment())
{
    // En entornos que no son de desarrollo, usa un manejador de excepciones para redirigir a una página de error.
    app.UseExceptionHandler("/Error");

    // Aplica la configuración predeterminada de HSTS (HTTP Strict Transport Security).
    // HSTS aumenta la seguridad en entornos de producción, forzando las conexiones HTTPS.
    app.UseHsts();
}

// Redirige todas las solicitudes HTTP a HTTPS para mejorar la seguridad.
app.UseHttpsRedirection();

// Habilita el servicio de archivos estáticos, permitiendo servir archivos como imágenes, CSS y JavaScript.
app.UseStaticFiles();

// Habilita el enrutamiento en la aplicación, necesario para las Razor Pages y otros endpoints.
app.UseRouting();

// Habilita la autorización, asegurando que ciertas páginas o rutas solo sean accesibles para usuarios autorizados.
app.UseAuthorization();

// Mapea las Razor Pages en el enrutador de la aplicación.
app.MapRazorPages();

// Ejecuta la aplicación web.
app.Run();