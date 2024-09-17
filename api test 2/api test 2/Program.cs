using api_test_2.DTOs;
using api_test_2.Mappers;
using api_test_2.Models;
using api_test_2.Repository;
using api_test_2.Services;
using api_test_2.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IBandsService<BandDto, BandInsertDto, BandUpdateDto>, BandsService>();


// Repository
builder.Services.AddScoped<ICommonRepository<Band>, BandRepository>();


// Entity Framework
builder.Services.AddDbContext<BandsContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("Bands2Connection"));
});

// Validators
builder.Services.AddScoped<IValidator<BandInsertDto>, BandInsertValidator>();
builder.Services.AddScoped<IValidator<BandUpdateDto>, BandUpdateValidator>();

// Automappers
builder.Services.AddAutoMapper(typeof(BandsMappingProfile));

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
