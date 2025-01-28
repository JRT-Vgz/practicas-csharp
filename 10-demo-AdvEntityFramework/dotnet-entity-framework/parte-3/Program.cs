using Cf.Dotnet.EntityFramework.Parte3;
using Microsoft.EntityFrameworkCore;

// Creación de un constructor de aplicaciones Web.
var builder = WebApplication.CreateBuilder(args);

// Nombre constante para la base de datos. Utilizado para definir la conexión a la base de datos.
const string databaseName = "MyDatabaseName";

// Registro de servicios Razor Pages en el contenedor de servicios.
builder.Services.AddRazorPages();

// Registro del contexto de la base de datos con Entity Framework y configuración para usar SQLite.
// Se usa una base de datos SQLite.
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlite($"Data Source={databaseName}"));

// Construcción de la aplicación.
var app = builder.Build();

// Configuración del pipeline de solicitudes HTTP.
if (!app.Environment.IsDevelopment())
{
    // Uso del manejador de excepciones en entornos que no son de desarrollo.
    app.UseExceptionHandler("/Error");
    // Uso de HSTS (HTTP Strict Transport Security) para mejorar la seguridad. Importante en escenarios de producción.
    app.UseHsts();
}

// Redirección automática de HTTP a HTTPS para mejorar la seguridad.
app.UseHttpsRedirection();
// Habilitación de archivos estáticos, como hojas de estilo, scripts y archivos de imagen.
app.UseStaticFiles();

// Configuración de enrutamiento para las solicitudes HTTP.
app.UseRouting();

// Habilitación de la autorización. Importante en aplicaciones que requieren autenticación y autorización.
app.UseAuthorization();

// Mapeo de Razor Pages en el pipeline de solicitudes HTTP.
app.MapRazorPages();

// Ejecución de la aplicación.
app.Run();