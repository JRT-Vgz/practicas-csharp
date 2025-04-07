
using ApplicationComponent;
using DomainComponent.SecondaryPorts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RepositoryComponent;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

string connectionString = configuration.GetConnectionString("DefaultConnection");

var service = new ServiceCollection();
service.AddDbContext<ItemsDBContext>(options =>
    options.UseSqlServer(connectionString));

service.AddTransient<IRepository, ItemRepository>();
service.AddTransient<IService, ItemService>();


var serviceProvider = service.BuildServiceProvider();
var itemService = serviceProvider.GetRequiredService<IService>();


while (true)
{
	try
	{
        Console.WriteLine("\nSelecciona una opción:");
        Console.WriteLine("1 - Agregar una tarea");
        Console.WriteLine("2 - Mostrar tareas");
        Console.WriteLine("3 - Salir");

        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                Console.WriteLine("Ingresa una tarea: ");
                string title = Console.ReadLine();
                await itemService.AddAsync(title);
                break;

            case "2":
                Console.WriteLine("Obteniendo tareas...");
                var items = await itemService.GetAsync();
                Console.WriteLine("Tareas almacenadas:");

                foreach (var item in items)
                {
                    Console.WriteLine($"[{(item.IsCompleted ? "X" : "")}] {item.Title}");
                }
                break;

            case "3":
                Console.WriteLine("Saliendo del sistema...");
                return;

            default:
                Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                break;
        }
    }
	catch (Exception ex)
	{
        Console.WriteLine($"Ocurrió un error: {ex.Message}");
    }
}