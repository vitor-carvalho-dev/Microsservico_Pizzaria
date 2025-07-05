using Microsoft.EntityFrameworkCore;
using Pizza.API.Models;

namespace Pizza.API.Persistence
{
    public class EstoqueRepository(PizzaDbContext dbContext)
    {
        public List<Estoque> GetAll() {
            return dbContext.Estoques.Include(e=>e.Pizza).ToList();
        }

        public Estoque GetById(int id)
        {
            var estoque = dbContext.Estoques.Include(e=>e.Pizza).FirstOrDefault(e => e.Id == id);

            if (estoque == null)
            {
                throw new NaoEncontradoException("Estoque não encontrado");
            }

            return estoque;
        }

        public Estoque Add(Estoque estoque) {
            var pizza = dbContext.Pizzas.FirstOrDefault(e => e.Id == estoque.PizzaId);

            if (pizza == null)
            {
                throw new ArgumentException("A pizza ainda não foi cadastrada");
            }

            var existeEstoque = dbContext.Estoques.FirstOrDefault(e => e.PizzaId == estoque.PizzaId);

            if (existeEstoque is not null)
            {
                throw new ArgumentException("Já existe estoque cadastrado para a pizza");
            }

            estoque.Pizza = pizza;

            dbContext.Estoques.Add(estoque);
            dbContext.SaveChanges();

            return estoque;
        }

        public Estoque GetByPizzaId(int pizzaId) {
            var estoque = dbContext.Estoques.Include(e=>e.Pizza).FirstOrDefault(e => e.PizzaId == pizzaId);

            if (estoque == null)
            {
                throw new NaoEncontradoException("Pizza não encontrada");
            }
            return estoque;
        }

        public async Task<Estoque> Update(int pizzaId, int quantidadeARemover)
        {
            var estoque = GetByPizzaId(pizzaId);

            if (quantidadeARemover > estoque.Quantidade)
            {
                throw new ArgumentException("A quantidade solicitada é superior ao estoque atual.");
            }

            estoque.Quantidade -= quantidadeARemover;
            estoque.AtualizadoEm = DateTime.UtcNow;

            dbContext.Update(estoque);
            dbContext.SaveChanges();

            return estoque;
        }
    }
}
