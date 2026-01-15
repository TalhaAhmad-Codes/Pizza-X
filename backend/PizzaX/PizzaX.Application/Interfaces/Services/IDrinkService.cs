using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.DrinkDTOs;
using PizzaX.Application.DTOs.DrinkDTOs.DrinkUpdateDtos;

namespace PizzaX.Application.Interfaces.Services
{
    public interface IDrinkService : IProductUpdateService<DrinkDto>
    {
        Task<PagedResultDto<DrinkDto>> GetAllAsync(DrinkFilterDto filterDto);

        // Update methods
        Task<DrinkDto?> UpdateCompanyDetailsAsync(DrinkUpdateDetailsCompanyNameDto dto);
        Task<DrinkDto?> UpdateRetailerNumberAsync(DrinkUpdateDetailsRetailerContactNumber dto);
    }
}
