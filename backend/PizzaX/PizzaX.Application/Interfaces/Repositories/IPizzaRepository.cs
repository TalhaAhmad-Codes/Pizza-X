using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.PizzaDTOs;
using PizzaX.Domain.Entities;

namespace PizzaX.Application.Interfaces.Repositories
{
    public interface IPizzaRepository : IGeneralRepository<Pizza>
    {
        Task<PagedResultDto<Pizza>> GetAllAsync(PizzaFilterDto filterDto);
    }
}
