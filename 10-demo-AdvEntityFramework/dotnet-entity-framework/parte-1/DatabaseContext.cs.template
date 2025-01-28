using Cf.Dotnet.EntityFramework.Parte1.Models;
using Microsoft.EntityFrameworkCore;

namespace Cf.Dotnet.EntityFramework.Parte1;

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
}