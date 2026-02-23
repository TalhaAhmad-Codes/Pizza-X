using Microsoft.EntityFrameworkCore;
using PizzaX.Application.Interfaces.Repositories;
using PizzaX.Domain.Entities;
using PizzaX.Infrastructure.Data;

namespace PizzaX.Infrastructure.Repositories
{
    public abstract class BaseProductRepository<P> : GeneralRepository<P>, IBaseProductRepository<P> where P : class
    {
        protected readonly DbSet<Product> dbSetProduct;

        public BaseProductRepository(PizzaXDbContext context) : base(context)
        {
            dbSetProduct = dbContext.Set<Product>();
        }

        public async Task<Product?> GetProductByIdAsync(Guid id)
            => await dbSetProduct.FindAsync(id);
    }
}
