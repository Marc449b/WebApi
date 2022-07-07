using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using JsonApi.DataAccess;
using JsonApi.DataAccess.Models.Derived.Misc.JsonEntity;
using JsonApi.DataAccess.UnitOfWork.Derived.Misc.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new()
    {
        Title = "Minimal API - Raw JSON data storage",
        Version = "v1",
        Description = "Storage for raw JSON data in a minimal API",
        License = new()
        {
            Name = "MIT License",
            Url = new Uri("https://github.com/ToxicK1dd/JsonApi/blob/master/LICENSE")
        }
    });
});
builder.Services.AddDataAccess(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.DocumentTitle = "Raw JSON data storage";
});
app.UseHttpsRedirection();


#region Endpoints
app.MapGet("/json/{id}", async (Guid id, IMiscUnitOfWork miscUnitOfWork, CancellationToken cancellationToken) =>
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
})
    .WithTags("JSON")
    .WithName("Get JSON by id");

app.MapPost("/json", async (object obj, IMiscUnitOfWork miscUnitOfWork, CancellationToken cancellationToken) =>
{
    try
    {
        var json = new JsonEntity()
        {
            Data = JObject.Parse(obj.ToString())
        };
        await miscUnitOfWork.JsonEntityRepository.AddAsync(json, cancellationToken);
        await miscUnitOfWork.SaveChangesAsync(cancellationToken);

        return Results.Created($"/json/{json.Id}", new { json.Id, Entities = JsonDocument.Parse(JsonConvert.SerializeObject(json.Data)) });
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }
})
    .WithTags("JSON")
    .WithName("Create JSON");

app.MapPut("/json/{id}", async (Guid id, object obj, IMiscUnitOfWork miscUnitOfWork, CancellationToken cancellationToken) =>
{
    try
    {
        var json = await miscUnitOfWork.JsonEntityRepository.GetByIdAsync(id, cancellationToken);
        if (json is null)
            Results.NotFound();

        var model = json.ToEntity();
        model.Data = JObject.Parse(obj.ToString());

        miscUnitOfWork.JsonEntityRepository.Update(model);
        await miscUnitOfWork.SaveChangesAsync(cancellationToken);

        return Results.Created($"/json/{json.Id}", new { json.Id, Entities = JsonDocument.Parse(JsonConvert.SerializeObject(model.Data)) });
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }
})
    .WithTags("JSON")
    .WithName("Update JSON");

app.MapDelete("/json/{id}", async (Guid id, IMiscUnitOfWork miscUnitOfWork, CancellationToken cancellationToken) =>
{
    try
    {
        var json = await miscUnitOfWork.JsonEntityRepository.GetByIdAsync(id, cancellationToken);
        if (json is null)
            Results.NotFound();

        var model = json.ToEntity();

        miscUnitOfWork.JsonEntityRepository.Remove(model);
        await miscUnitOfWork.SaveChangesAsync(cancellationToken);

        return Results.Ok();
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }
})
    .WithTags("JSON")
    .WithName("Delete JSON");

#endregion

app.Run();