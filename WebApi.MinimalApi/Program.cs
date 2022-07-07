using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using WebApi.DataAccess;
using WebApi.DataAccess.Models.Derived.Misc.JsonEntity;
using WebApi.DataAccess.UnitOfWork.Derived.Misc.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDataAccess(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/json/{id}", async (IMiscUnitOfWork miscUnitOfWork, CancellationToken cancellationToken, Guid id) =>
{
    try
    {
        var json = await miscUnitOfWork.JsonEntityRepository.GetByIdAsync(id, cancellationToken);
        return json is not null ? Results.Ok(new { json.Id, Entities = JsonDocument.Parse(JsonConvert.SerializeObject(json.Entities)) }) : Results.NotFound();
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }
});

app.MapPost("/json", async (object obj, IMiscUnitOfWork miscUnitOfWork, CancellationToken cancellationToken) =>
{
    try
    {
        var json = new JsonEntity()
        {
            Data = JObject.Parse(obj.ToString()!)
        };
        await miscUnitOfWork.JsonEntityRepository.AddAsync(json, cancellationToken);
        await miscUnitOfWork.SaveChangesAsync(cancellationToken);

        return Results.Created($"/json/{json.Id}", new { json.Id, Entities = JsonDocument.Parse(JsonConvert.SerializeObject(json.Data)) });
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }
});


app.Run();