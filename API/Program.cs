using AddressBookApp.Application.Interfaces;
using AddressBookApp.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Address Book API",
        Version = "v1",
        Description = "API REST para gestionar contactos. Implementada con .NET 8 y Minimal API siguiendo Clean Architecture.",
        Contact = new()
        {
            Name = "Carlos Quijada",
            Email = "carlosqm97@hotmail.com",
            Url = new Uri("https://github.com/carlosqm09")
        }
    });
});
builder.Services.AddSingleton<IContactService, JsonContactService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.DocumentTitle = "📘 Libreta de Contactos - API REST";
    options.DisplayRequestDuration();
    options.HeadContent = """
    <style>
        body { font-family: 'Roboto', sans-serif; font-weight: 600; }
        .topbar {
            background-color: #1976d2 !important;
        }
        .topbar-wrapper img { display: none !important; }
        .topbar-wrapper span { display: inline-block; margin-left: 60px; }
        .swagger-ui .topbar .download-url-wrapper { margin-left: auto; }
    </style>
    <link href='https://fonts.googleapis.com/css2?family=Roboto:wght@600&display=swap' rel='stylesheet'>
""";
    options.SupportedSubmitMethods(new[] { Swashbuckle.AspNetCore.SwaggerUI.SubmitMethod.Get, Swashbuckle.AspNetCore.SwaggerUI.SubmitMethod.Delete });
});

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