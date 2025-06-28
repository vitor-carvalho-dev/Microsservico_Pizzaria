using Microsoft.EntityFrameworkCore;
using Pedidos.API.HttpClients;
using Pedidos.API.Persistence;
using Pedidos.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PedidoDbContext>(options => 
    options.UseInMemoryDatabase("pedidos"));

builder.Services.AddScoped<PedidoRepository>();
builder.Services.AddScoped<PedidoService>();

builder.Services.AddHttpClient<PizzaApiHttpClient.Client>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
