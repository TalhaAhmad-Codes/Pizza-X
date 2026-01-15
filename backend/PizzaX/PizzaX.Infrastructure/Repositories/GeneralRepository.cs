using Microsoft.EntityFrameworkCore;
using PizzaX.Application.Interfaces.Repositories;
using PizzaX.Domain.Common;
using PizzaX.Infrastructure.Data;

namespace PizzaX.Infrastructure.Repositories
{
    public abstract class GeneralRepository<Entity> : IGeneralRepository<Entity> where Entity : class
    {
        protected readonly PizzaXDbContext dbContext;
        protected readonly DbSet<Entity> dbSet;

        protected GeneralRepository(PizzaXDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<Entity>();
        }

        // Get entity by its Id
        public async Task<Entity?> GetByIdAsync(Guid id)
            => await dbSet.FindAsync(id);

        // Add an entity to the database
        public async Task AddAsync(Entity entity)
        {
            dbContext.Add(entity);
            await dbContext.SaveChangesAsync();
        }

        // Delete an entity from the database
        public async Task RemoveAsync(Entity entity)
        {
            dbSet.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        // Update an entity into database
        public async Task UpdateAsync(Entity entity)
        {
            dbSet.Update(entity);
            await dbContext.SaveChangesAsync();
        }

        // Get paged result items
        protected async Task<List<Entity>> GetPagedResultItemsAsync(IQueryable<Entity> query, int pageNumber, int pageSize)
        {
            return await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
