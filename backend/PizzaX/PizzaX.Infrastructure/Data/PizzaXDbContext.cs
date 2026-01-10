using Microsoft.EntityFrameworkCore;
using PizzaX.Domain.Entities;

namespace PizzaX.Infrastructure.Data
{
    public sealed class PizzaXDbContext : DbContext
    {
        // Constructor
        public PizzaXDbContext(DbContextOptions<PizzaXDbContext> options) : base(options) { }

        /*// <----- DbSets -----> //*/
        public DbSet<User> Users => Set<User>();
        public DbSet<Pizza> Pizzas => Set<Pizza>();
        public DbSet<PizzaVariety> PizzaVarieties => Set<PizzaVariety>();
        public DbSet<Fries> Fries => Set<Fries>();
        public DbSet<FriesCategory> FriesCategories => Set<FriesCategory>();
        public DbSet<Drink> Drinks => Set<Drink>();
    }
}
