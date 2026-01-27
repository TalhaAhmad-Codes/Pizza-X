using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.ProductDTOs;
using PizzaX.Domain.Entities;

namespace PizzaX.Application.Interfaces.Repositories
{
    public interface IProductRepository : IGeneralRepository<Product>
    {
        Task<PagedResultDto<Product>> GetAllAsync(ProductFilterDto filterDto);
    }
}
