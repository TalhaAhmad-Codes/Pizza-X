using Microsoft.EntityFrameworkCore;
using PizzaX.ApplicationCore.Interfaces.Repositories;
using PizzaX.Domain.Common;
using PizzaX.Infrastructure.Data;

namespace PizzaX.Infrastructure.Repositories
{
    public abstract class Repository<T>: IRepository<T> where T : class
    {
        protected readonly PizzaXDbContext _context;
        protected readonly DbSet<T> _set;

        protected Repository(PizzaXDbContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        public async Task<IQueryable<T>?> GetAllAsync()
            => _set.AsQueryable();

        public async Task<T?> GetByIdAsync(int id)
            => await _set.FindAsync(id);

        public async Task AddAsync(T entity)
        {
            await _set.AddAsync(entity);
        }

        public async Task<T> UpdateAsync(int id)
        {
            var obj = await GetByIdAsync(id);
            if (obj is null)
                throw new DomainException($"The entity of Id '{id}' not found.");

            _set.Update(obj);
            return obj;
        }

        public async Task DeleteAsync(int id)
        {
            var obj = await GetByIdAsync(id);
            if (obj is null)
                throw new DomainException($"The entity of Id '{id}' not found.");

            _set.Remove(obj);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
