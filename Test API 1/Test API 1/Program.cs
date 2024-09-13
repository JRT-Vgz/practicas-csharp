using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Test_API_1.DTOs;
using Test_API_1.Models;
using Test_API_1.Services;
using Test_API_1.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IBandsService, BandsService>();



// Entity Framework
builder.Services.AddDbContext<MetalContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("MetalConnection"));
});


// Validators
builder.Services.AddScoped<IValidator<BandInsertDto>, BandInsertValidator>();
builder.Services.AddScoped<IValidator<BandUpdateDto>, BandUpdateValidator>();


builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
