using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.PizzaVarietyDTOs;
using PizzaX.Domain.Entities;

namespace PizzaX.Application.Interfaces.Repositories
{
    public interface IPizzaVarietyRepository : IGeneralRepository<PizzaVariety>
    {
        Task<PagedResultDto<PizzaVariety>> GetAllAsync(PizzaVarietyFilterDto filterDto);
    }
}
