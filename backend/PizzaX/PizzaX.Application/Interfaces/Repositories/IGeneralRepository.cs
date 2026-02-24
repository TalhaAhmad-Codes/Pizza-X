namespace PizzaX.Application.Interfaces.Repositories
{
    public interface IGeneralRepository<Entity> where Entity : class
    {
        Task<Entity?> GetByIdAsync(Guid id);
        Task AddAsync(Entity entity, bool saveChanges = true);
        Task RemoveAsync(Entity entity);
        Task UpdateAsync(Entity entity);
        Task SaveChangesAsync();
    }
}
