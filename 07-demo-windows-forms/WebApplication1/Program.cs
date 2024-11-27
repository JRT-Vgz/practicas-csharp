using _1_Entities;
using _2_Services;
using _3_Data;
using _3_Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// ENTITY FRAMEWORK
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySQL("server=127.0.0.1; uid=root; pwd=jebimalo666; database=wformdemo");
});

builder.Services.AddScoped<IRepository<Brand>, BrandRepository>();
builder.Services.AddScoped<AddBrand>();
builder.Services.AddScoped<GetAllBrand>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.MapGet("/db", (GetAllBrand brand) =>
{
    return brand.ExecuteAsync();
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();


