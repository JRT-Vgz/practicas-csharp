using Cf.Dotnet.EntityFramework.Parte2Extra.ModelConfigurations;
using Cf.Dotnet.EntityFramework.Parte2Extra.Models;
using Microsoft.EntityFrameworkCore;

namespace Cf.Dotnet.EntityFramework.Parte2Extra;

/// <summary>
///     Contexto de la base de datos para la aplicación, que utiliza Entity Framework.
/// </summary>
public class DatabaseContext : DbContext
{
    /// <summary>
    ///     Constructor sin parámetros para el contexto de la base de datos.
    /// </summary>
    /// <remarks>
    ///     Este constructor es utilizado principalmente por frameworks y herramientas de desarrollo, como por ejemplo, para la
    ///     creación de migraciones.
    /// </remarks>
    public DatabaseContext()
    {
    }

    /// <summary>
    ///     Constructor que toma opciones de DbContext para configurar el contexto.
    /// </summary>
    /// <param name="options">Opciones de configuración para el contexto de la base de datos.</param>
    /// <remarks>
    ///     Este constructor permite configurar el contexto con opciones específicas, como la cadena de conexión a la base de
    ///     datos.
    /// </remarks>
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    /// <summary>
    ///     Conjunto de entidades de tipo CatalogItem en la base de datos.
    /// </summary>
    /// <value>
    ///     Proporciona acceso a las operaciones CRUD para los elementos del catálogo.
    /// </value>
    public DbSet<CatalogItem> CatalogItems { get; set; } =
        null!; // Inicializa con null! para indicar que EF se encargará de su inicialización.

    /// <summary>
    ///     Conjunto de entidades de tipo Order en la base de datos.
    /// </summary>
    /// <value>
    ///     Proporciona acceso a las operaciones CRUD para las órdenes.
    /// </value>
    public DbSet<Order> Orders { get; set; } = null!; // DbSet<Order> se inicializa con null! como una convención de EF.

    /// <summary>
    ///     Conjunto de entidades de tipo Customer en la base de datos.
    /// </summary>
    /// <value>
    ///     Proporciona acceso a las operaciones CRUD para los clientes.
    /// </value>
    public DbSet<Customer> Customers { get; set; } =
        null!; // DbSet<Customer> también se inicializa con null!, delegando la inicialización a EF.

    /// <summary>
    ///     Método de configuración para definir opciones adicionales del contexto de base de datos.
    ///     Se ejecuta durante la inicialización del contexto y se utiliza para configurar el proveedor de base de datos, entre otros ajustes.
    /// </summary>
    /// <param name="optionsBuilder">Constructor de opciones para configurar el contexto.</param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Configura el proveedor de base de datos SQLite si no se ha configurado previamente.
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer($"Data Source=localhost,1433;User ID=sa;Password=Passw@rd;Database=MyDatabaseName;Encrypt=False")
                .UseLoggerFactory(LoggerFactory.Create(builder =>
                    builder.AddConsole().SetMinimumLevel(LogLevel.Information)));

    }
}