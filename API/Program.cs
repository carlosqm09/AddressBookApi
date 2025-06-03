using AddressBookApp.Application.Interfaces;
using AddressBookApp.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IContactService, JsonContactService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/contacts", (IContactService service, string? phrase) =>
{
    try
    {
        var contacts = service.GetAll(phrase);
        return Results.Ok(contacts);
    }
    catch (ArgumentException)
    {
        return Results.BadRequest();
    }
});

app.MapGet("/contacts/{id}", (IContactService service, int id) =>
{
    var contact = service.GetById(id);
    return contact is not null ? Results.Ok(contact) : Results.NotFound();
});

app.MapDelete("/contacts/{id}", (IContactService service, int id) =>
{
    var deleted = service.Delete(id);
    return deleted ? Results.NoContent() : Results.NotFound();
});

app.MapMethods("/contacts", new[] { "POST", "PUT", "PATCH" }, () => Results.StatusCode(405)).ExcludeFromDescription();
app.MapMethods("/contacts/{id}", new[] { "POST", "PUT", "PATCH" }, () => Results.StatusCode(405)).ExcludeFromDescription();

app.MapFallback(() => Results.NotFound());

app.Run();