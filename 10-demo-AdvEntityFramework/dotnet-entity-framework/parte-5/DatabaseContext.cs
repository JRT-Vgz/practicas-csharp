using AutoBogus;
using Bogus.Extensions;
using Cf.Dotnet.EntityFramework.Parte5.Models;
using Microsoft.EntityFrameworkCore;

namespace Cf.Dotnet.EntityFramework.Parte5;

/// <summary>
///     Contexto de la base de datos para la aplicación, utilizando Entity Framework.
///     Define las entidades y realiza configuraciones iniciales para el modelo de la base de datos.
/// </summary>
public class DatabaseContext : DbContext
{
    /// <summary>
    ///     Constructor sin parámetros para el contexto de la base de datos.
    ///     Utilizado principalmente por frameworks y herramientas de desarrollo.
    /// </summary>
    public DatabaseContext()
    {
    }

    /// <summary>
    ///     Constructor que toma opciones de DbContext para configurar el contexto.
    ///     Permite inyectar configuraciones específicas, como la cadena de conexión a la base de datos.
    /// </summary>
    /// <param name="options">Opciones de configuración para el contexto de la base de datos.</param>
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    // Definiciones de DbSet para las entidades del modelo.
    public DbSet<CatalogItem> CatalogItems { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<Customer> Customers { get; set; } = null!;

    /// <summary>
    ///     Configura el modelo de la base de datos, incluyendo la generación de datos ficticios iniciales.
    ///     Utiliza AutoBogus para generar datos de prueba automáticamente.
    /// </summary>
    /// <param name="modelBuilder">Constructor de modelos para definir configuraciones del modelo.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Número de elementos ficticios a generar para cada entidad.
        const int seedItems = 10;

        // Generación de datos ficticios para clientes.
        var customers = new AutoFaker<Customer>()
            .RuleFor(x => x.Id, f => f.Random.Int(0))
            .RuleFor(x => x.Orders, new List<Order>())
            .Generate(seedItems);

        // Generación de datos ficticios para artículos del catálogo.
        var catalogitems = new AutoFaker<CatalogItem>()
            .RuleFor(x => x.Id, f => f.Random.Int(0))
            .Generate(seedItems);

        // Generación de datos ficticios para órdenes.
        var orders = new AutoFaker<Order>()
            .RuleFor(x => x.Id, f => f.Random.Int(0))
            .RuleFor(x => x.CustomerId, f => f.PickRandom(customers.Select(c => c.Id)))
            .RuleFor(x => x.CatalogItemId, f => f.PickRandom(catalogitems.Select(c => c.Id)))
            .RuleFor(x => x.Customer, default(Customer))
            .RuleFor(x => x.CatalogItem, default(CatalogItem))
            .RuleFor(x => x.Quantity, f => f.Random.Decimal2(0, 999999))
            .Generate(seedItems);

        // Agrega los datos ficticios generados al modelo.
        modelBuilder.Entity<Customer>().HasData(customers);
        modelBuilder.Entity<CatalogItem>().HasData(catalogitems);
        modelBuilder.Entity<Order>().HasData(orders);
    }
}