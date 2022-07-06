using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using WebApi.DataAccess;
using WebApi.DataAccess.Models.Derived.Misc.JsonObject;
using WebApi.DataAccess.UnitOfWork.Derived.Misc.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDataAccess();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/json", async (object obj, IMiscUnitOfWork miscUnitOfWork, CancellationToken cancellationToken) =>
{
    try
    {
        var json = new JsonEntity()
        {
            Entities = JObject.Parse(obj.ToString()!)
        };
        await miscUnitOfWork.JsonEntityRepository.AddAsync(json, cancellationToken);
        await miscUnitOfWork.SaveChangesAsync(cancellationToken);

        return Results.Created($"/json/{json.Id}", new { json.Id, Entities = JsonDocument.Parse(JsonConvert.SerializeObject(json.Entities)) });
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }
});


app.MapGet("/json/{id}", async (IMiscUnitOfWork miscUnitOfWork, CancellationToken cancellationToken, Guid id) =>
{
    try
    {
        var json = await miscUnitOfWork.JsonEntityRepository.GetByIdAsync(id, cancellationToken);
        return Results.Ok(new { json.Id, Entities = JsonDocument.Parse(JsonConvert.SerializeObject(json.Entities)) });
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }
}).WithName("GetJson");

app.Run();