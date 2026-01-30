using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.DealDTOs;
using PizzaX.Application.DTOs.DealDTOs.DealUpdateDtos;

namespace PizzaX.Application.Interfaces.Services
{
    public interface IDealService
    {
        Task<PagedResultDto<DealDto>> GetAllAsync(DealFilterDto filterDto);

        Task<DealDto?> GetByIdAsync(Guid id);
        Task<DealDto> CreateAsync(CreateDealDto dto);
        Task<bool> RemoveAsync(Guid id);
        Task<bool> UpdateNameAsync(DealUpdateNameDto dto);
        Task<bool> UpdateDescriptionAsync(DealUpdateDescriptionDto dto);
        Task<bool> AddDealItemAsync(DealAddDealItemDto dto);
        Task<bool> RemoveDealItemAsync(DealRemoveDealItemDto dto);
    }
}
