using Pizza.API.Exceptions;
using Pizza.API.Models;

namespace Pizza.API.Persistencia
{
    public class PizzaRepository
    {
        private static List<Models.Pizza> _pizza = [];

        public List<Models.Pizza> GetAll()
        {
            return _pizza;
        }

        public Models.Pizza Add(Models.Pizza pizza) 
        {
            var novoId = _pizza.Any() ? _pizza.Max(p => p.Id) + 1 : 1;
            pizza.Id = novoId;
            _pizza.Add(pizza);
            return pizza;
            
        }

        public Models.Pizza? GetById(int id)
        {
            var pizza = _pizza.FirstOrDefault(p => p.Id == id);

            if (pizza == null) 
            {
                throw new NaoEncontrado("Nao tem pizza com esse id");
            }
            return pizza;
        }


    }
}
