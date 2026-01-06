using Microsoft.EntityFrameworkCore;

namespace PizzaX.Infrastructure.Data
{
    public sealed class PizzaXDbContext : DbContext
    {
        // Constructor
        public PizzaXDbContext(DbContextOptions<PizzaXDbContext> options) : base(options) { }

        /*/ <----- DbSets -----> /*/
    }
}
