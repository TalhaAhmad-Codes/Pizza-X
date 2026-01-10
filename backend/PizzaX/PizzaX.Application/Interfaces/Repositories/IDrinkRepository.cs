using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.DrinkDTOs;
using PizzaX.Application.DTOs.DrinkDTOs.DrinkUpdateDtos;
using PizzaX.Domain.Entities;

namespace PizzaX.Application.Interfaces.Repositories
{
    public interface IDrinkRepository : IGeneralRepository<Drink>
    {
        Task<PagedResultDto<Drink>> GetAllAsync(DrinkFilterDto filterDto);

        // Update methods
        Task<Drink?> UpdateImageAsync(DrinkUpdateImageDto imageDto);
        Task<Drink?> UpdatePriceAsync(DrinkUpdatePriceDto priceDto);
        Task<Drink?> UpdateQuantityAsync(DrinkUpdateQuantityDto quantityDto);
        Task<Drink?> UpdateDescriptionAsync(DrinkUpdateDescriptionDto descriptionDto);
        Task<Drink?> UpdateDetailsCompanyNameAsync(DrinkUpdateDetailsCompanyNameDto companyNameDto);
        Task<Drink?> UpdateDetailsRetailerContactNumberAsync(DrinkUpdateDetailsRetailerContactNumber numberDto);
    }
}
