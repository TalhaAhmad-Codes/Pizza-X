using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.PizzaVarietyDTOs;
using PizzaX.Application.DTOs.PizzaVarietyDTOs.PizzaVarietyUpdateDtos;

namespace PizzaX.Application.Interfaces.Services
{
    public interface IPizzaVarietyService
    {
        Task<PagedResultDto<PizzaVarietyDto>> GetAllAsync(PizzaVarietyFilterDto filterDto);

        // Basic methods
        Task<PizzaVarietyDto?> GetByIdAsync(Guid id);
        Task<PizzaVarietyDto> CreateAsync(CreatePizzaVarietyDto dto);
        Task<bool> RemoveAsync(Guid id);

        // Update method
        Task<PizzaVarietyNameUpdateDto?> GetUpdateNameDtoValues(Guid id);
        Task<bool> UpdateNameAsync(Guid id, PizzaVarietyNameUpdateDto dto);
    }
}
