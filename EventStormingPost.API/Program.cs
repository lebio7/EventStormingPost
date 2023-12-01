using EventStormingPost.Application.Features.Post.Commands;
using EventStormingPost.Infrastructure;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Dodanie us³ug do kontenera.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

// Dodanie obs³ugi MediatR
builder.Services.AddMediatR(Assembly.GetExecutingAssembly(), typeof(CreateHandler).Assembly);
builder.Services.AddInfrastructure();

var app = builder.Build();

// Konfiguracja potoku ¿¹dania HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Mapowanie kontrolerów
app.MapControllers();

app.Run();