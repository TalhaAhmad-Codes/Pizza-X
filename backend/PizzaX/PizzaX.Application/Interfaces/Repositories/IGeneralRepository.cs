namespace PizzaX.Application.Interfaces.Repositories
{
    public interface IGeneralRepository<Entity> where Entity : class
    {
        Task<Entity?> GetByIdAsync(Guid id);
        Task AddAsync(Entity entity);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(Entity entity);
        Task<List<Entity>> GetPagedResultItemsAsync(IQueryable<Entity> query, int pageNumber, int pageSize);
    }
}
