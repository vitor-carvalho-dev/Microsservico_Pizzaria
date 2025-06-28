using Microsoft.EntityFrameworkCore;
using Pedidos.API.Models;


namespace Pedidos.API.Persistence
{
    public class PedidoDbContext(DbContextOptions<PedidoDbContext> options)
        : DbContext(options)
    {
        public DbSet<Pedido> Pedidos { get; set; } = null;

    }
}
