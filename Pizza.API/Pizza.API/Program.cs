// Pizza API


using Microsoft.EntityFrameworkCore;
using Pizza.API.Persistencia;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PizzaDbContext>(options => options.UseInMemoryDatabase("pizza"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<PizzaRepository>();

builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseExceptionHandler("/error");

app.Run();
