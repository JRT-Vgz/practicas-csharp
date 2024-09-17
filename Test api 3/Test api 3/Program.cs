using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Test_api_3.AutoMappers;
using Test_api_3.DTOs;
using Test_api_3.Models;
using Test_api_3.Repository;
using Test_api_3.Services;
using Test_api_3.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICommonService<BandDto, BandInsertDto, BandUpdateDto>, BandsService>();


// Entity Framework
builder.Services.AddDbContext<BandsContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("BandsConnection"));
});

// Repository
builder.Services.AddScoped<IRepository<Band>, BandsRepository>();

//Mappers
builder.Services.AddAutoMapper(typeof(MappingProfile));

//Validators
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
