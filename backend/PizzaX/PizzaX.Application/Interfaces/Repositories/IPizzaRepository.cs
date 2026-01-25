using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.PizzaDTOs;
using PizzaX.Domain.Entities;
using PizzaX.Domain.Enums.Pizza;

namespace PizzaX.Application.Interfaces.Repositories
{
    public interface IPizzaRepository : IGeneralRepository<Pizza>
    {
        Task<bool> ExistsBySizeAndVariety(PizzaSize size, Guid varietyId);
        Task<PagedResultDto<Pizza>> GetAllAsync(PizzaFilterDto filterDto);
    }
}
