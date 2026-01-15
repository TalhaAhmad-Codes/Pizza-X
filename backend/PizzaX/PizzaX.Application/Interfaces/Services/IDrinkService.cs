using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.DrinkDTOs;
using PizzaX.Application.DTOs.DrinkDTOs.DrinkUpdateDtos;

namespace PizzaX.Application.Interfaces.Services
{
    public interface IDrinkService : IProductUpdateService
    {
        Task<PagedResultDto<DrinkDto>> GetAllAsync(DrinkFilterDto filterDto);

        // Update methods
        Task<bool> UpdateCompanyDetailsAsync(DrinkUpdateDetailsCompanyNameDto dto);
        Task<bool> UpdateRetailerNumberAsync(DrinkUpdateDetailsRetailerContactNumber dto);
    }
}
