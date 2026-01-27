using PizzaX.Application.DTOs.BaseCategoryDTOs;
using PizzaX.Application.DTOs.BaseCategoryDTOs.BaseCategoryUpdateDtos;
using PizzaX.Application.DTOs.Common;

namespace PizzaX.Application.Interfaces.Services
{
    public interface IPizzaVarietyService
    {
        Task<PagedResultDto<BaseCategoryDto>> GetAllAsync(BaseCategoryFilterDto filterDto);

        // Basic methods
        Task<BaseCategoryDto?> GetByIdAsync(Guid id);
        Task<BaseCategoryDto> CreateAsync(CreateBaseCategoryDto dto);
        Task<bool> RemoveAsync(Guid id);

        // Update method
        Task<bool> UpdateNameAsync(BaseCategoryUpdateNameDto dto);
    }
}
