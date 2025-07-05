using Microsoft.AspNetCore.Mvc;
using Pizza.API.Models;
using Pizza.API.Persistence;

namespace Pizza.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstoqueController(EstoqueRepository _estoqueRepository) : ControllerBase
    {
        [HttpGet]
        public List<Estoque> GetAll()
        {
            return _estoqueRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var estoque = _estoqueRepository.GetById(id);
            return Ok(estoque);

        }

        [HttpPost]
        public ActionResult<Estoque> Create(Estoque estoque)
        {
            _estoqueRepository.Add(estoque);
            return CreatedAtAction(nameof(GetById), new { id = estoque.Id }, estoque);
        }

        [HttpGet("pizza/{pizzaId}")]
        public Estoque GetByPizzaId(int pizzaId)
        {
            return _estoqueRepository.GetByPizzaId(pizzaId);
        }

        [HttpPut("pizza/{pizzaId}/{quantidade}")]
        public async Task<ActionResult<Estoque>> Update(int pizzaId, int quantidade)
        {
            try
            {
                return await _estoqueRepository.Update(pizzaId, quantidade);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}