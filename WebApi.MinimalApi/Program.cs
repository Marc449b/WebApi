using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using WebApi.DataAccess;
using WebApi.DataAccess.Models.Derived.Misc.JsonObject;
using WebApi.DataAccess.UnitOfWork.Derived.Misc;
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

app.MapPost("/json", async (string data, IMiscUnitOfWork miscUnitOfWork, CancellationToken cancellationToken) =>
{
    var json = new JsonEntity()
    {
        Entities = JObject.Parse(data)
    };
    await miscUnitOfWork.JsonEntityRepository.AddAsync(json, cancellationToken);
    await miscUnitOfWork.SaveChangesAsync(cancellationToken);

    return Results.Created($"/json/{json.Id}", json);
});


app.MapGet("/json/{id}", async ([FromServices] IMiscUnitOfWork miscUnitOfWork, CancellationToken cancellationToken, Guid id) =>
{
    var json = await miscUnitOfWork.JsonEntityRepository.GetByIdAsync(id, cancellationToken);

    return Results.Ok(json);
}).WithName("GetJson");

app.Run();