using Microsoft.EntityFrameworkCore;

namespace Pizza.API.Persistencia
{
    public class PizzaDbContext(DbContextOptions<PizzaDbContext> options) : DbContext(options)
    {
        public DbSet<Models.Pizza> Pizzas { get; set; }
        public DbSet<Models.Estoque> Estoques { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Pizza>().HasKey(p => p.Id);
            modelBuilder.Entity<Models.Pizza>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Models.Estoque>().HasKey(p => p.Id);
            modelBuilder.Entity<Models.Estoque>().Property(p => p.Id).ValueGeneratedOnAdd();

            // 1 estoque => N Pizzas
            modelBuilder.Entity<Models.Estoque>()
                .HasOne(e => e.Pizza) // 1 estoque => 1 pizza
                .WithOne() // 1 pizza => 1 estoque
                .HasForeignKey<Models.Estoque>(e => e.PizzaId)
                .IsRequired();

            modelBuilder.Entity<Models.Estoque>()
                .Property(e => e.Quantidade)
                .IsRequired();

            modelBuilder.Entity<Models.Estoque>().Property(e => e.Quantidade).IsRequired();

         //   modelBuilder.Entity<Models.Pizza>()
         //       .HasData(
         //                   new Models.Pizza()
         //                   {
         //                       Id = 1,
         //                       Nome = "Calabresa",
         //                       TempoPreparo = 10,
         //                       Preco = 20,
         //                   },
         //                   new Models.Pizza()
         //                   {
         //                       Id = 2,
         //                       Nome = "Portuguesa",
         //                       TempoPreparo = 10,
         //                       Preco = 20,
         //                   },
         //                   new Models.Pizza()
         //                   {
         //                       Id = 3,
         //                       Nome = "Quatro Queijo",
         //                       TempoPreparo = 10,
         //                       Preco = 20,
         //                   }
         //               );
        }
    }
}
