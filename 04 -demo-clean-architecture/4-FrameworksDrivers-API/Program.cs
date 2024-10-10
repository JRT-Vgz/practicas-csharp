using _1_EnterpriseLayer;
using _2_ApplicationLayer;
using _3_InterfaceAdapters_Adapters;
using _3_InterfaceAdapters_Adapters.Dtos;
using _3_InterfaceAdapters_Data;
using _3_InterfaceAdapters_Mappers;
using _3_InterfaceAdapters_Mappers.Dtos.Requests;
using _3_InterfaceAdapters_Models;
using _3_InterfaceAdapters_Presenters;
using _3_InterfaceAdapters_Repository;
using _4_FrameworksDrivers_API.Middlewares;
using _4_FrameworksDrivers_API.Validators;
using _4_FrameworksDrivers_ExternalService;
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
builder.Services.AddScoped<IRepository<Sale>, SaleRepository>();
builder.Services.AddScoped<IRepositorySearch<SaleModel, Sale>, SaleRepository>();
builder.Services.AddScoped<IPresenter<Beer, BeerViewModel>, BeerPresenter>();
builder.Services.AddScoped<IPresenter<Beer, BeerDetailViewModel>, BeerDetailPresenter>();
builder.Services.AddScoped<IMapper<BeerRequestDto, Beer>, BeerMapper>();
builder.Services.AddScoped<IMapper<SaleRequestDto, Sale>, SaleMapper>();
builder.Services.AddScoped<IExternalServiceAdapter<Post>, PostExternalServiceAdapter>();
builder.Services.AddScoped<IExternalService<PostServiceDto>, PostService>();

// Use Cases
builder.Services.AddScoped<GetBeerUseCase<Beer, BeerViewModel>>();
builder.Services.AddScoped<GetBeerUseCase<Beer, BeerDetailViewModel>>();
builder.Services.AddScoped<AddBeerUseCase<BeerRequestDto>>();
builder.Services.AddScoped<GetPostUseCase>();
builder.Services.AddScoped<GenerateSaleUseCase<SaleRequestDto>>();
builder.Services.AddScoped<GetSaleUseCase>();
builder.Services.AddScoped<GetSaleSearchUseCase<SaleModel>>();

// Entity Framework
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("BreweryConnection"));
});

// Validators
builder.Services.AddValidatorsFromAssemblyContaining<BeerValidator>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

// Http Client
builder.Services.AddHttpClient<IExternalService<PostServiceDto>, PostService> (c =>
{
    c.BaseAddress = new Uri(builder.Configuration["BaseUrlPosts"]);
});

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


// ENDPOINTS //

// BEER GET ALL
app.MapGet("/beer", async (GetBeerUseCase<Beer, BeerViewModel> beerUseCase) =>
{
    return await beerUseCase.GetAllAsync();
})
.WithName("beers")
.WithOpenApi();

// BEER POST
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

// BEER DETAIL
app.MapGet("/beerDetail", async (GetBeerUseCase<Beer, BeerDetailViewModel> beerUseCase) =>
{
    return await beerUseCase.GetAllAsync();
})
.WithName("beerDetail")
.WithOpenApi();

// EXTERNAL SERVICE: GET ALL POST
app.MapGet("/posts", async (GetPostUseCase postUseCase) =>
{
    return await postUseCase.GetAllAsync();
})
.WithName("posts")
.WithOpenApi();

// GENERATE SALE
app.MapPost("/sale", async (SaleRequestDto saleRequestDto,
    GenerateSaleUseCase<SaleRequestDto> saleUseCase) =>
{
    await saleUseCase.ExecuteAsync(saleRequestDto);
    return Results.Created();
})
.WithName("generateSale")
.WithOpenApi();

// GET SALE
app.MapGet("/sale", async (GetSaleUseCase saleUseCase) =>
{
    return await saleUseCase.ExecuteAsync();
})
.WithName("getSale")
.WithOpenApi();

// GET SALE SEARCH
app.MapGet("/salesearch/{total}", async (GetSaleSearchUseCase<SaleModel> saleUseCase,
    decimal total) =>
{
    return await saleUseCase.ExecuteAsync(s => s.Total >= total);
})
.WithName("getSaleSearch")
.WithOpenApi();


app.Run();

