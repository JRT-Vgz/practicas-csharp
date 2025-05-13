using ApplicationComponent;
using ApplicationComponent.DTOs;
using DomainComponent.Entities;
using DomainComponent.SecondaryPorts;
using MapperComponent;
using Microsoft.EntityFrameworkCore;
using RepositoryComponent;
using RepositoryComponent.ExtraData;
using RepositoryComponent.Factories;
using RepositoryComponent.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// DEPENDENCIES
builder.Services.AddDbContext<ItemsDBContext>(options =>
    options.UseSqlServer(connectionString));

// ITEM
builder.Services.AddTransient<IRepository, ItemRepository>();
builder.Services.AddTransient<IService, ItemService>();

// NOTE
builder.Services.AddTransient<ICommonRepository<Note>, NoteRepository>();
builder.Services.AddTransient<ICommonService<Note>, NoteService>();

// NOTE DTO
builder.Services.AddTransient<ICommonRepository<NoteDTO>, NoteDTORepository>();
builder.Services.AddTransient<ICommonService<NoteDTO>, NoteDTOService>();

// MAPPER
builder.Services.AddTransient<IAddRepository<NoteModel>, NoteMapperRepository>();
builder.Services.AddTransient<IMapper<NoteDTO, Note>, NoteEntityMapper>();
builder.Services.AddTransient<IMapper<NoteDTO, NoteModel>, NoteModelMapper>();
builder.Services.AddTransient<IAddService<NoteDTO, NoteModel>, NoteMapperService<NoteDTO, NoteModel>>();

// FACTORY
builder.Services.AddTransient<IRepositoryFactory<IAddRepository<Note>, NoteExtraData>, NoteRepositoryFactory>();
builder.Services.AddTransient<IMapper<NoteDTO, NoteExtraData>, NoteExtraDataMapper>();
builder.Services.AddTransient<IAddService<NoteDTO, NoteExtraData>, NoteWithFactoryService<NoteDTO, NoteExtraData>>();


// COMPLETAR ITEM
builder.Services.AddTransient<ICompleteService, CompleteItemService>();
builder.Services.AddTransient<ICompleteRepository, ItemRepository>();
builder.Services.AddTransient<IGetRepository<Item>, ItemRepository>();



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


// ITEM ENDPOINTS.
app.MapGet("/items", async (IService service) =>
{
    return await service.GetAsync();
}).WithName("GetItems");

app.MapPost("/items", async (string title, IService service) =>
{
    await service.AddAsync(title);
    return Results.Created();
}).WithName("AddItems");


// NOTE ENDPOINTS.
app.MapGet("/notes", async (ICommonService<Note> service) =>
{
    return await service.GetAsync();
}).WithName("GetNotes");

app.MapPost("/notes", async (Note note, ICommonService<Note> service) =>
{
    await service.AddAsync(note);
    return Results.Created();
}).WithName("AddNotes");


// NOTE DTO ENDPOINTS.
app.MapGet("/notesdto", async (ICommonService<NoteDTO> service) =>
{
    return await service.GetAsync();
}).WithName("GetNotesDTO");

app.MapPost("/notesdto", async (NoteDTO noteDTO, ICommonService<NoteDTO> service) =>
{
    await service.AddAsync(noteDTO);
    return Results.Created();
}).WithName("AddNotesDTO");


// MAPPER ENDPOINTS.
app.MapPost("/nitesmapper", async (NoteDTO note, IAddService<NoteDTO, NoteModel> service) =>
{
    await service.AddAsync(note);
    return Results.Created();
}).WithName("addNotesMapper");


// FACTORY ENDPOINTS.
app.MapPost("notesfactory", async (NoteDTO note, IAddService<NoteDTO, NoteExtraData> service) =>
{
    await service.AddAsync(note);
    return Results.Created();
}).WithName("AddNotesFactory");



// COMPLETE ITEM
app.MapPost("completeitem/{id}", async (ICompleteService service, int id) =>
{
    try
    {
        await service.Complete(id);
        return Results.NoContent();
    }
    catch (InvalidOperationException ex)
    {
        return Results.NotFound(ex.Message);
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }
}).WithName("CompleteItem");


app.Run();


