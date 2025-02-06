using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SwaggerAndConsumeServices.Models.Data;
using System;
using System.Reflection;
using System.Text;
[assembly: ApiConventionType(typeof(DefaultApiConventions))]
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(
    configuration =>
    {
        // Indica que el controlador responde a solicitudes HTTP con un tipo de contenido JSON
        configuration.ReturnHttpNotAcceptable = true;

        // Agrega un filtro de respuesta para las respuestas de error
        //configuration.Filters.Add(
        //    new ProducesResponseTypeAttribute(
        //        StatusCodes.Status400BadRequest));
        //configuration.Filters.Add(
        //    new ProducesResponseTypeAttribute(
        //        StatusCodes.Status404NotFound));
        //configuration.Filters.Add(
        //    new ProducesResponseTypeAttribute(
        //        StatusCodes.Status500InternalServerError));

    }).AddJsonOptions(setupAction =>
    {
        // Establece la configuración de serialización de JSON propertyNamingPolicy y dictionaryKeyPolicy en null
        // Esto significa que los nombres de las propiedades y las claves de los diccionarios no se modificarán
        setupAction.JsonSerializerOptions.PropertyNamingPolicy = null;
       // setupAction.JsonSerializerOptions.DictionaryKeyPolicy = null;
    }
    );

IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                            .Build();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<DataContext>(options =>
                                        {
                                            options.UseInMemoryDatabase("Products");
                                        });
builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "SwaggerAndConsumeServices",
            Version = "v1",
            Description = "A simple example ASP.NET Core Web API",
            Contact = new OpenApiContact
            {
                Name = "John Doe",
                Email = ""
            },
            License = new OpenApiLicense
            {
                Name = "Use under LICX",
                Url = new Uri("https://example.com/license")
            },

        });

    setupAction.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id="Bearer"
                            },
                            Name="Bearer",
                            In=ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });

    var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);
    setupAction.IncludeXmlComments(xmlCommentsFullPath);
});
//builder.Services.AddAuthorization();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.IncludeErrorDetails = true;
    //o.RequireHttpsMetadata = false;
    //o.SaveToken = true;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddHttpClient();

var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI(setupAction =>
{
    setupAction.SwaggerEndpoint(
        "/swagger/v1/swagger.json",
        "SwaggerAndConsumeServices API v1");
    //setupAction.RoutePrefix = "";
    setupAction.RoutePrefix = "swagger";
    setupAction.DocumentTitle = "SwaggerAndConsumeServices";
    //Controla cómo se expanden los documentos en la interfaz de usuario de Swagger. El valor None significa que todos los documentos estarán colapsados por defecto
    setupAction.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.List);
    //Define cómo se renderizarán los modelos en la interfaz de usuario de Swagger. En este caso, se establece para mostrar solo el modelo sin detalles adicionales
    setupAction.DefaultModelRendering(Swashbuckle.AspNetCore.SwaggerUI.ModelRendering.Model);
    // Habilita la visualización de la duración de las solicitudes en la interfaz de usuario de Swagger, útil para medir el rendimiento de la API 
    setupAction.DisplayRequestDuration();
    //Habilita la funcionalidad de filtrado en la interfaz de usuario de Swagger, lo que permite a los usuarios buscar operaciones específica
    setupAction.EnableFilter();
});
//}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
