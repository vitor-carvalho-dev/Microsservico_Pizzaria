// PIZZA API

using Microsoft.EntityFrameworkCore;
using Pizza.API.Percistence;
using Pizza.API.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PizzaDbContext>(optins => 
    optins.UseInMemoryDatabase("pizza"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<PizzaRepository>();
builder.Services.AddScoped<EstoqueRepository>();
builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.UseExceptionHandler("/error");
app.Run();
