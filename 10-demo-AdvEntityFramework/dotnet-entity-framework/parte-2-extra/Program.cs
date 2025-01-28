using System.Data;
using Cf.Dotnet.EntityFramework.Parte2Extra;
using Cf.Dotnet.EntityFramework.Parte2Extra.Models;
using Microsoft.EntityFrameworkCore;

// Creación de un logger para registrar la actividad del programa.
var logger = LoggerFactory
    .Create(builder => builder.AddConsole().SetMinimumLevel(LogLevel.Debug))
    .CreateLogger<Program>();

// Creación de una instancia del contexto de la base de datos con las opciones configuradas.
await using var context = new DatabaseContext();
await using var transaction = await context.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

// Creación y adición de un nuevo cliente al contexto.
var customer = new Customer
{
    Name = "Miguel"
};

context.Customers.Add(customer);
await context.SaveChangesAsync();
logger.LogDebug("Customer {CustomerId} created", customer.Id);

// Creación y adición de una lista de artículos del catálogo al contexto.
var catalogItems = new List<CatalogItem>
{
    new()
    {
        Name = "Item 1",
        Price = 10
    },
    new()
    {
        Name = "Item 2",
        Price = 20
    }
};

context.CatalogItems.AddRange(catalogItems);
await context.SaveChangesAsync();
logger.LogDebug("Catalog items {CatalogItemIds} created", string.Join(", ", catalogItems.Select(x => x.Id)));

// Búsqueda de un artículo del catálogo por su identificador.
// Todos las entidades implementan la interfaz IQueryable<T>,
// Por lo que se pueden utilizar métodos de extensión de Linq.
//
// NOTA: Todos las operaciones que se hagan utilizando un IQueryable<T> se traducen a una consulta SQL.
// Por lo que se ejecutan en el servidor de base de datos.
// Cuando las consultas se ejecutan sobre un IEnumerable<T> estas ocurren en memoria. 
// Lo que puede ser un problema de rendimiento cuando se tienen grandes cantidades de datos.
var catalog = await context.CatalogItems
    .Where(item => item.Price > 10)
    .FirstAsync();

// Creación y adición de una orden al contexto.
var order = new Order
{
    CustomerId = customer.Id,
    CatalogItemId = catalog.Id,
    Quantity = 1
};

context.Orders.Add(order);
await context.SaveChangesAsync();
transaction.Commit();

order.Quantity = 2;
context.Orders.Update(order);
await context.SaveChangesAsync();