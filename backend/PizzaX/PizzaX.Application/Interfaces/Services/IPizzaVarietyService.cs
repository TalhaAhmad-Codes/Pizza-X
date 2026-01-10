using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.PizzaVarietyDTOs;
using PizzaX.Application.DTOs.PizzaVarietyDTOs.PizzaVarietyUpdateDtos;

namespace PizzaX.Application.Interfaces.Services
{
    public interface IPizzaVarietyService
    {
        Task<PagedResultDto<PizzaVarietyDto>> GetAllAsync(PizzaVarietyFilterDto filterDto);

        // Update method
        Task<PizzaVarietyDto?> UpdateNameAsync(PizzaVarietyNameUpdateDto nameDto);
    }
}
