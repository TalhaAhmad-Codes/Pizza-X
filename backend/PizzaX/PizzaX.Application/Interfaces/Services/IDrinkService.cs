using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.DrinkDTOs;
using PizzaX.Application.DTOs.DrinkDTOs.DrinkUpdateDtos;

namespace PizzaX.Application.Interfaces.Services
{
    public interface IDrinkService
    {
        Task<PagedResultDto<DrinkDto>> GetAllAsync(DrinkFilterDto filterDto);

        // Update methods
        Task<DrinkDto?> UpdateImageAsync(DrinkUpdateImageDto imageDto);
        Task<DrinkDto?> UpdatePriceAsync(DrinkUpdatePriceDto priceDto);
        Task<DrinkDto?> UpdateQuantityAsync(DrinkUpdateQuantityDto quantityDto);
        Task<DrinkDto?> UpdateDescriptionAsync(DrinkUpdateDescriptionDto descriptionDto);
        Task<DrinkDto?> UpdateDetailsAsync(DrinkUpdateDetailsDto detailsDto);
    }
}
