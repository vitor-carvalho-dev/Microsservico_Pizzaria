using Microsoft.AspNetCore.Mvc;
using Pedidos.API.Models;
using Pedidos.API.Services;

namespace Pedidos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController(PedidoService pedidoService) : ControllerBase
    {

        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetById(Guid id)
        {
            try
            {
                return pedidoService.GetById(id);
            }
            catch (System.Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public List<Pedido> GetAll()
        {
            return pedidoService.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult<Pedido>> Add(Pedido pedido)
        {
            await pedidoService.Add(pedido);
            return CreatedAtAction(nameof(GetById), new {id = pedido.Id}, pedido);
        }
    }
}
