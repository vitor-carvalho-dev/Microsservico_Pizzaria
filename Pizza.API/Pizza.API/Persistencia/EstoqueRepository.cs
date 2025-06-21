using Pizza.API.Exceptions;
using Pizza.API.Models;

namespace Pizza.API.Persistencia
{
    public class EstoqueRepository(PizzaDbContext dbContext)
    {
        public List<Estoque> GetAll() {

            return dbContext.Estoques.ToList();
        }

        public Estoque GetById(int id) 
        {
            var estoque = dbContext.Estoques.FirstOrDefault(e => e.Id == id);

            if (estoque == null) {

                throw new NaoEncontrado("Estoque nao encontrado");
            }

            return estoque;
        }

        public Estoque Add(Estoque estoque) {
            
            var pizza = dbContext.Pizzas.FirstOrDefault(p => p.Id == estoque.PizzaId);

            if (pizza == null) {
                throw new ArgumentException("A pizza ainda nao foi cadastrada!"); 
            }

            var existeEstoque = dbContext.Estoques.FirstOrDefault(e => e.PizzaId == estoque.PizzaId);

            if (existeEstoque is not null)
            {
                throw new NaoEncontrado("Ja existe estoque cadastrado para a pizza");
            }

            estoque.Pizza = pizza;

            dbContext.Estoques.Add(estoque);
            dbContext.SaveChanges();    

            return estoque; 
        }

        public Estoque GetByPizzaId(int pizzaId) 
        {
            var estoque = dbContext.Estoques.FirstOrDefault(e => e.PizzaId == pizzaId);

            if (estoque is null)
            {
                throw new NaoEncontrado("Nao tem pizza com esse id");
            }
            return estoque;
        }

        public Estoque Update(int pizzaId, int quantidadeRemover)
        {
            var estoque = GetByPizzaId(pizzaId);

            if (quantidadeRemover > estoque.Quantidade)
            {
                throw new ArgumentException("A quantidade é superior ao estoque atual");
            }
            estoque.Quantidade -= quantidadeRemover;
            estoque.AtualizadoEm = DateTime.UtcNow;

            dbContext.Update(estoque);
            dbContext.SaveChanges();
            return estoque;
        }

        
    }
}
