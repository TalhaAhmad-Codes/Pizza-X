using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.FriesDTOs;
using PizzaX.Application.DTOs.FriesDTOs.FriesUpdateDtos;
using PizzaX.Domain.Entities;

namespace PizzaX.Application.Interfaces.Repositories
{
    public interface IFriesRepository : IGeneralRepository<Fries>
    {
        Task<PagedResultDto<Fries>> GetAllAsync(FriesFilterDto filterDto);

        // Update methods
        Task<Fries?> UpdateImageAsync(FriesUpdateImageDto imageDto);
        Task<Fries?> UpdatePriceAsync(FriesUpdatePriceDto priceDto);
        Task<Fries?> UpdateQuantityAsync(FriesUpdateQuantityDto qualityDto);
        Task<Fries?> UpdateDescriptionAsync(FriesUpdateDescriptionDto descriptionDto);
    }
}
