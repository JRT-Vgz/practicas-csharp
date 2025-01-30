using Cf.Dotnet.EntityFramework.Parte2.Models;
using Microsoft.EntityFrameworkCore;

namespace Cf.Dotnet.EntityFramework.Parte2;

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
}