namespace Pizza.API.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;

        public int TempoPreparo { get; set; }

        public DateTime? DataCriacao { get; set; } = DateTime.MinValue;

        public decimal? Preco { get; set; }
}
}
