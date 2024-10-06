
using _1_EnterpriseLayer;
using _2_ApplicationLayer;
using _3_InterfaceAdapters_Data;
using _3_InterfaceAdapters_Presenters;
using _3_InterfaceAdapters_Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

IConfiguration configuration = builder.Build();

var container = new ServiceCollection()
    // Entity Framework
    .AddDbContext<AppDbContext>(options =>
    { options.UseMySQL(configuration.GetConnectionString("BreweryConnection")); })
    // Interfaces
    .AddScoped<IRepository<Beer>, Repository>()
    .AddScoped<IPresenter<Beer, BeerViewModel>, BeerPresenter>()
    // Use Cases
    .AddScoped<GetBeerUseCase<Beer, BeerViewModel>>()
    .BuildServiceProvider();

var getBeerUseCase = container.GetService<GetBeerUseCase<Beer, BeerViewModel>>();
var beers = await getBeerUseCase.GetAllAsync();

foreach (var beer in beers)
{
    Console.WriteLine($"Cerveza {beer.Name} com {beer.Alcohol} alcohol.");
}


