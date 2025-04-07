using Domain.Ports.Primary;
using Domain.Ports.Secondary;
using Domain.Services;
using XMLRepository;

var builder = WebApplication.CreateBuilder(args);


// INYECCIÓN DE DEPENDENCIAS
string pathFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "products.xml");

builder.Services.AddTransient<IRepository>(provider => new XMLProductRepository(pathFile));
builder.Services.AddTransient<IService, ProductService>();



// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


// ENDPOINTS
app.MapGet("/products", (IService service) =>
{
    return service.GetAll();
}).WithName("GetProducts");

app.MapPost("/products", (string name, decimal price, IService service) =>
{
    service.Register(name, price);
    return Results.Created();
}).WithName("AddProduct");


app.Run();


