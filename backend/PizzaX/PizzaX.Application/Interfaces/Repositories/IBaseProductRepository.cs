using PizzaX.Domain.Entities;

namespace PizzaX.Application.Interfaces.Repositories
{
    public interface IBaseProductRepository<P> : IGeneralRepository<P> where P : class
    {
        Task<Product?> GetProductByIdAsync(Guid id);
    }
}
