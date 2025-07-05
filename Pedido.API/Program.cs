using Microsoft.EntityFrameworkCore;
using Pedidos.API.HttpClients;
using Pedidos.API.Persistence;
using Pedidos.API.Services;
using Steeltoe.Common.Http.Discovery;
using Steeltoe.Discovery.Client;
using Steeltoe.Discovery.Consul;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks();
builder.Services.AddServiceDiscovery(options =>
    options.UseConsul());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PedidoDbContext>(options => 
    options.UseInMemoryDatabase("pedidos"));

builder.Services.AddScoped<PedidoRepository>();
builder.Services.AddScoped<PedidoService>();

builder.Services.AddHttpClient<PizzaApiHttpClient.Client>(options =>
    options.BaseAddress = new Uri("http://pizza-service")).AddServiceDiscovery();

builder.Services.AddHttpClient<NotificacoesApiHttpClient.ClientNotification>(options =>
    options.BaseAddress = new Uri("http://notificacoes-service")).AddServiceDiscovery();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseHealthChecks("/health");
app.Run();
