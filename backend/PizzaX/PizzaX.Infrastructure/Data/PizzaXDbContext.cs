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
    }
}
