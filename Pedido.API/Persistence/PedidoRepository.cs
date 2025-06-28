using Pedidos.API.Models;

namespace Pedidos.API.Persistence
{
    public class PedidoRepository(PedidoDbContext dbContext)
    {
        public List<Pedido> GetAll()
        {
            return dbContext.Pedidos.ToList();
        }

        public Pedido? GetById(Guid id)
        {
            return dbContext.Pedidos.Find(id);
        }

        public Pedido Add(Pedido pedido)
        {

            dbContext.Pedidos.Add(pedido);
            dbContext.SaveChanges();

            return pedido;
        }
    }
}
