using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.PizzaDTOs;
using PizzaX.Application.DTOs.PizzaDTOs.PizzaUpdateDtos;

namespace PizzaX.Application.Interfaces.Services
{
    public interface IPizzaService
    {
        Task<PagedResultDto<PizzaDto>> GetAllAsync(PizzaFilterDto filterDto);

        // Update methods
        Task<PizzaDto?> UpdateImageAsync(PizzaUpdateImageDto imageDto);
        Task<PizzaDto?> UpdatePriceAsync(PizzaUpdatePriceDto priceDto);
        Task<PizzaDto?> UpdateQuantityAsync(PizzaUpdateQuantityDto quantityDto);
        Task<PizzaDto?> UpdateDescriptionAsync(PizzaUpdateDescriptionDto descriptionDto);
    }
}
