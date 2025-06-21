using Microsoft.EntityFrameworkCore;

namespace Pizza.API.Persistencia
{
    public class PizzaDbContext(DbContextOptions<PizzaDbContext> options) : DbContext
    {
        public DbSet<Models.Pizza> Pizzas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Pizza>().HasKey(p => p.Id);
            modelBuilder.Entity<Models.Pizza>().Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}
