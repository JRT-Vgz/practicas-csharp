using _1_EnterpriseLayer;
using _2_ApplicationLayer;
using _3_InterfaceAdapters_Data;
using _3_InterfaceAdapters_Mappers;
using _3_InterfaceAdapters_Mappers.Dtos.Requests;
using _3_InterfaceAdapters_Models;
using _3_InterfaceAdapters_Presenters;
using _3_InterfaceAdapters_Repository;
using _4_FrameworksDrivers_API.Middlewares;
using _4_FrameworksDrivers_API.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// DEPENDENCIAS
// Interfaces
builder.Services.AddScoped<IRepository<Beer>, Repository>();
builder.Services.AddScoped<IPresenter<Beer, BeerViewModel>, BeerPresenter>();
builder.Services.AddScoped<IPresenter<Beer, BeerDetailViewModel>, BeerDetailPresenter>();
builder.Services.AddScoped<IMapper<BeerRequestDto, Beer>, BeerMapper>();

// Use Cases
builder.Services.AddScoped<GetBeerUseCase<Beer, BeerViewModel>>();
builder.Services.AddScoped<GetBeerUseCase<Beer, BeerDetailViewModel>>();
builder.Services.AddScoped<AddBeerUseCase<BeerRequestDto>>();

// Entity Framework
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("BreweryConnection"));
});

// Validators
builder.Services.AddValidatorsFromAssemblyContaining<BeerValidator>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Middleware
app.UseMiddleware<ExceptionMiddleware>();


app.MapGet("/beer", async (GetBeerUseCase<Beer, BeerViewModel> beerUseCase) =>
{
    return await beerUseCase.GetAllAsync();
})
.WithName("beers")
.WithOpenApi();


app.MapPost("/beer", async (BeerRequestDto beerRequestDto, 
    AddBeerUseCase<BeerRequestDto> beerUseCase,
    IValidator<BeerRequestDto> validator) =>
{
    var formValidation = await validator.ValidateAsync(beerRequestDto);
    if (!formValidation.IsValid) { return Results.ValidationProblem(formValidation.ToDictionary()); }

    await beerUseCase.AddAsync(beerRequestDto);
    return Results.Created();
})
.WithName("addBeer")
.WithOpenApi();


app.MapGet("/beerDetail", async (GetBeerUseCase<Beer, BeerDetailViewModel> beerUseCase) =>
{
    return await beerUseCase.GetAllAsync();
})
.WithName("beerDetail")
.WithOpenApi();




app.Run();

