using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.DrinkDTOs;
using PizzaX.Application.DTOs.DrinkDTOs.DrinkUpdateDtos;

namespace PizzaX.Application.Interfaces.Services
{
    public interface IDrinkService : IProductUpdateService
    {
        Task<PagedResultDto<DrinkDto>> GetAllAsync(DrinkFilterDto filterDto);

        // Basic methods
        Task<DrinkDto?> GetByIdAsync(Guid id);
        Task<DrinkDto> CreateAsync(CreateDrinkDto dto);
        Task<bool> RemoveAsync(Guid id);

        // Update methods
        Task<bool> UpdateCompanyDetailsAsync(DrinkUpdateDetailsCompanyNameDto dto);
        Task<bool> UpdateRetailerNumberAsync(DrinkUpdateDetailsRetailerContactNumber dto);
    }
}
