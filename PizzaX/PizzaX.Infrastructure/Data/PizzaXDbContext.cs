using Microsoft.EntityFrameworkCore;
using PizzaX.Domain.Employees.Entities;
using PizzaX.Domain.Orders.Entities;
using PizzaX.Domain.Pizzas.Entities;
using PizzaX.Domain.Users.Entities;

namespace PizzaX.Infrastructure.Data
{
    public sealed class PizzaXDbContext : DbContext
    {
        /*// <----- DbSets -----> //*/
        public DbSet<User> Users => Set<User>();
        public DbSet<Pizza> Pizzas => Set<Pizza>();
        public DbSet<PizzaVariety> PizzaVarieties => Set<PizzaVariety>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Employee> Employees => Set<Employee>();

        // Constructor
        public PizzaXDbContext(DbContextOptions<PizzaXDbContext> options) : base(options) { }
    }
}
