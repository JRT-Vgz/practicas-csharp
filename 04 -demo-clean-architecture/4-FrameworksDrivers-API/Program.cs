using _1_EnterpriseLayer;
using _2_ApplicationLayer;
using _3_InterfaceAdapters_Data;
using _3_InterfaceAdapters_Mappers;
using _3_InterfaceAdapters_Mappers.Dtos.Requests;
using _3_InterfaceAdapters_Models;
using _3_InterfaceAdapters_Presenters;
using _3_InterfaceAdapters_Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Dependencias
builder.Services.AddScoped<IRepository<Beer>, Repository>();
builder.Services.AddScoped<IPresenter<Beer, BeerViewModel>, BeerPresenter>();
builder.Services.AddScoped<IMapper<BeerRequestDto, Beer>, BeerMapper>();

builder.Services.AddScoped<GetBeerUseCase<Beer, BeerViewModel>>();
builder.Services.AddScoped<AddBeerUseCase<BeerRequestDto>>();


// Entity Framework
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("BreweryConnection"));
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/beer", async (GetBeerUseCase<Beer, BeerViewModel> beerUseCase) =>
{
    return await beerUseCase.GetAllAsync();
})
.WithName("beers")
.WithOpenApi();

app.MapPost("/beer", async (BeerRequestDto beerRequestDto, AddBeerUseCase<BeerRequestDto> beerUseCase) =>
{
    await beerUseCase.AddAsync(beerRequestDto);
    return Results.Created();
})
.WithName("addBeer")
.WithOpenApi();

app.Run();

