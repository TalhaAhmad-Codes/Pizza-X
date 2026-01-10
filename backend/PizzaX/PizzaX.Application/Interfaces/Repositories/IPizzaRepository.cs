using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.PizzaDTOs;
using PizzaX.Application.DTOs.PizzaDTOs.PizzaUpdateDtos;
using PizzaX.Domain.Entities;

namespace PizzaX.Application.Interfaces.Repositories
{
    public interface IPizzaRepository : IGeneralRepository<Pizza>
    {
        Task<PagedResultDto<Pizza>> GetAllAsync(PizzaFilterDto filterDto);

        // Update methods
        Task<Pizza?> UpdateImageAsync(PizzaUpdateImageDto imageDto);
        Task<Pizza?> UpdatePriceAsync(PizzaUpdatePriceDto priceDto);
        Task<Pizza?> UpdateQuantityAsync(PizzaUpdateQuantityDto quantityDto);
        Task<Pizza?> UpdateDescriptionAsync(PizzaUpdateDescriptionDto descriptionDto);
    }
}
