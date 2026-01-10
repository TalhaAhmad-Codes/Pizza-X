using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.PizzaVarietyDTOs;
using PizzaX.Application.DTOs.PizzaVarietyDTOs.PizzaVarietyUpdateDtos;
using PizzaX.Domain.Entities;

namespace PizzaX.Application.Interfaces.Repositories
{
    public interface IPizzaVarietyRepository : IGeneralRepository<PizzaVariety>
    {
        Task<PagedResultDto<PizzaVariety>> GetAllAsync(PizzaVarietyFilterDto filterDto);

        // Update method
        Task<PizzaVariety?> UpdateNameAsync(PizzaVarietyNameUpdateDto nameDto);
    }
}
