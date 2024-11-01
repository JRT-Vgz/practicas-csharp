using csharp_api_demo_bands.Automappers;
using csharp_api_demo_bands.DTOs;
using csharp_api_demo_bands.Models;
using csharp_api_demo_bands.Repository;
using csharp_api_demo_bands.Services;
using csharp_api_demo_bands.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICommonService<StyleDto, StyleInsertDto, StyleUpdateDto>, StyleService>();
builder.Services.AddScoped<BandService>();
builder.Services.AddScoped<ICommonService<BandDto, BandInsertDto, BandUpdateDto>>(s => s.GetService<BandService>());
builder.Services.AddScoped<ICommonServiceValidate<BandInsertDto, BandUpdateDto>>(s => s.GetService<BandService>());

// Repository
builder.Services.AddScoped<IRepository<Style>, StyleRepository>();
builder.Services.AddScoped<IRepository<Band>, BandRepository>();

// Mappers
builder.Services.AddAutoMapper(typeof(Program));

// Validators
builder.Services.AddScoped<IValidator<StyleInsertDto>, StyleInsertValidator>();
builder.Services.AddScoped<IValidator<StyleUpdateDto>, StyleUpdateValidator>();
builder.Services.AddScoped<IValidator<BandInsertDto>, BandInsertValidator>();
builder.Services.AddScoped<IValidator<BandUpdateDto>, BandUpdateValidator>();

// Entity Framework
builder.Services.AddDbContext<BandsContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("BandsConnection"));
});


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
