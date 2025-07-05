using System.ComponentModel.DataAnnotations;

namespace Pedidos.API.Models
{
    public class Pedido
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [EmailAddress]
        public string Cliente { get; set; } = string.Empty;
        public int PizzaId { get; set; }
        public int Quantidade { get; set; }
        public enum SituacaoEnum
        {
            Recebido,
            EmPreparacao,
            Finalizado
        }
        public SituacaoEnum SituacaoId { get; set; } = SituacaoEnum.Recebido;
        public string Situacao => SituacaoId.ToString();
        public DateTime CriadoEm {  get; set; } = DateTime.UtcNow;
        public DateTime AtualizadoEm {  get; set; } 
    }
}
