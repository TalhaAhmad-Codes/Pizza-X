using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.FriesDTOs;
using PizzaX.Application.DTOs.FriesDTOs.FriesUpdateDtos;

namespace PizzaX.Application.Interfaces.Services
{
    public interface IFriesService
    {
        Task<PagedResultDto<FriesDto>> GetAllAsync(FriesFilterDto filterDto);

        // Update methods
        Task<FriesDto?> UpdateImageAsync(FriesUpdateImageDto imageDto);
        Task<FriesDto?> UpdatePriceAsync(FriesUpdatePriceDto priceDto);
        Task<FriesDto?> UpdateQualityAsync(FriesUpdateQuantityDto qualityDto);
        Task<FriesDto?> UpdateDescriptionAsync(FriesUpdateDescriptionDto descriptionDto);
    }
}
