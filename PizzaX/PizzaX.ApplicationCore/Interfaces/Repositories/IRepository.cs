using PizzaX.ApplicationCore.DTOs.Common;

namespace PizzaX.ApplicationCore.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IQueryable<T>?> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task SaveChangesAsync();
    }
}
