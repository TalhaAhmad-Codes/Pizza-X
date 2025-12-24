using PizzaX.ApplicationCore.DTOs.Common;

namespace PizzaX.ApplicationCore.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IQueryable<T>?> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task<T> UpdateAsync(int id);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
