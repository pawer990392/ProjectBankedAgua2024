using WaterSystem.Infrastructure.Extensions;
using WaterSystem.Application.Extensions;
using WaterSystem.Api.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var configurations = builder.Configuration;

// Agregar servicios de infraestructura y aplicación
builder.Services.AddInjectionInfrastructure(configurations);
builder.Services.AddInjectionApplication(configurations);
//builder.Services.AddAuthentication(configurations);

// Configurar CORS
const string CorsPolicyName = "CorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CorsPolicyName,
        builder =>
        {
            builder.WithOrigins("*");
            builder.AllowAnyMethod();
            builder.AllowAnyHeader();
        });
});

// Agregar controladores y configuración de Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Habilitar CORS
app.UseCors(CorsPolicyName);

// Configurar middleware de Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
    {
     endpoints.MapControllers();
 });

app.Run();

public partial class Program { }
