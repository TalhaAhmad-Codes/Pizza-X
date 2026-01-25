namespace PizzaX.Application.Interfaces.Repositories
{
    public interface IGeneralRepository<Entity> where Entity : class
    {
        Task<Entity?> GetByIdAsync(Guid id);
        Task AddAsync(Entity entity);
        Task RemoveAsync(Entity entity);
        Task UpdateAsync(Entity entity);
    }
}
