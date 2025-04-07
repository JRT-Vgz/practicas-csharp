
using Domain.Ports.Primary;
using Domain.Ports.Secondary;
using Domain.Services;
using JsonRepository;
using Microsoft.Extensions.DependencyInjection;

string pathFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "products.json");

var services = new ServiceCollection();
services.AddTransient<IRepository>(provider => new ProductRepository(pathFile));
services.AddTransient<IService, ProductService>();

var serviceProvider = services.BuildServiceProvider();

var productService = serviceProvider.GetService<IService>();

while (true) 
{
	try
	{
		Console.WriteLine("\nSeleccione una opción:");
        Console.WriteLine("1 - Agregar un producto");
        Console.WriteLine("2 - Mostrar productos almacenados");
        Console.WriteLine("3 - Salir");

		string option = Console.ReadLine();
		switch (option)
		{
			case "1":
                Console.WriteLine("Ingresa el producto: ");
				string name = Console.ReadLine();
                Console.WriteLine("Ingresa el precio: ");
				decimal price = decimal.Parse(Console.ReadLine());

				productService.Register(name, price);
				break;

			case "2":
				Console.WriteLine("\nProductos almacenados:");
				foreach (var product in productService.GetAll())
				{
					Console.WriteLine($"Nombre: {product.Name}, Precio: {product.Price}.");
				}
				break;

			case "3":
                Console.WriteLine("Saliendo del sistema.");
				return;

			default:
				Console.WriteLine("Opción no válida, intenta de nuevo.");
				break;
        }

	}
	catch (Exception ex)
	{
        Console.WriteLine($"Ocurrió un error: {ex.Message}");
    }

}
