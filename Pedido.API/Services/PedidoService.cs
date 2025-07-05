using Pedidos.API.Exceptions;
using Pedidos.API.HttpClients;
using Pedidos.API.Models;
using Pedidos.API.Persistence;

namespace Pedidos.API.Services
{
    public class PedidoService(
        PedidoRepository repository,
        PizzaApiHttpClient.Client pizzaApi)
    {
        // Obter por id
        public Pedido GetById(Guid id)
        {
            var pedido = repository.GetById(id);

            if (pedido == null)
            {
                throw new NaoEncontradoException("Pedido não encontrado.");
            }

            return pedido;
        }

        // Obter todos
        public List<Pedido> GetAll()
        {
            return repository.GetAll();
        }

        // Adicionar
        public async Task<Pedido> Add(Pedido pedido)
        {
            // 1. Verificar se pizza existe
            var estoque = await pizzaApi.GetEstoque(pedido.PizzaId);
            if (estoque == null || estoque.Quantidade < pedido.Quantidade)
            {
                throw new Exception("Estoque insuficiente");
            }
            
            // 2. Salvar o pedido
            // 3. Atualiza o estoque
            await pizzaApi.UpdateEstoque(pedido.PizzaId, pedido.Quantidade);
            repository.Add(pedido);
            
            // 4. Notificar o cliente

            return pedido;
        }


    }
}
