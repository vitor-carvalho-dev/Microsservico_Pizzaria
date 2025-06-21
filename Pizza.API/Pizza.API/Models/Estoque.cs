using System.ComponentModel.DataAnnotations;

namespace Pizza.API.Models
{

    public class Estoque
    {
        public int Id { get; set; }
        public int PizzaId { get; set; }
        public Pizza? Pizza { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Minimo de 1 unidade")]
        public int Quantidade { get; set; }
        public DateTime? CriadoEm { get; set; } = DateTime.Now;
        public DateTime? AtualizadoEm { get; set; } = DateTime.Now;
    }  

}
