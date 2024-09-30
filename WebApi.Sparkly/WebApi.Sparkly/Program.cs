using System.Configuration;
using Microsoft.EntityFrameworkCore;
using WebApi.Sparkly.Context;
using WebApi.Sparkly.Services.Implementaciones;
using WebApi.Sparkly.Services.Interfaces;
using WebApi.Sparkly.Services.Implementaciones; // Nueva línea
using WebApi.Sparkly.Services.Interfaces;
using MyApp.Services.Implementaciones; // Nueva línea

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var conString = builder.Configuration.GetConnectionString("Conn");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(conString, ServerVersion.AutoDetect(conString))
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Agregar el servicio IUserService
builder.Services.AddScoped<IUserService, UserService>(); // Nueva línea
builder.Services.AddScoped<ICitaService, CitaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
