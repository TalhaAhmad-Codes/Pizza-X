using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.FriesCategoryDTOs;
using PizzaX.Application.DTOs.FriesCetagoryDTOs;
using PizzaX.Application.DTOs.FriesCetagoryDTOs.FriesCetagoryUpdateDtos;

namespace PizzaX.Application.Interfaces.Services
{
    public interface IFriesCetagoryService
    {
        Task<PagedResultDto<FriesCategoryDto>> GetAllAsync(FriesCategoryFilterDto filterDto);

        // Basic methods
        Task<FriesCategoryDto?> GetByIdAsync(Guid id);
        Task<FriesCategoryDto> CreateAsync(CreateFriesCategoryDto dto);
        Task<bool> RemoveAsync(Guid id);

        // Update method
        Task<bool> UpdateNameAsync(FriesCetagoryUpdateNameDto dto);
    }
}
