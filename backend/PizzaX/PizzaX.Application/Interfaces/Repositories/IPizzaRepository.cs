using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.PizzaDTOs;
using PizzaX.Domain.Entities;
using PizzaX.Domain.Enums.Pizza;

namespace PizzaX.Application.Interfaces.Repositories
{
    public interface IPizzaRepository : IBaseProductRepository<Pizza>
    {
        Task<Pizza?> GetSimilarVarietyAndSizePizzaAsync(Guid varietyId, PizzaSize pizzaSize);
        Task<PagedResultDto<Pizza>> GetAllAsync(PizzaFilterDto filterDto);
    }
}
