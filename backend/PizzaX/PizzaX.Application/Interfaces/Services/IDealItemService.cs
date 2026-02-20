using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.DealItemDTOs;
using PizzaX.Application.DTOs.DealItemDTOs.DealItemUpdateDtos;

namespace PizzaX.Application.Interfaces.Services
{
    public interface IDealItemService
    {
        Task<PagedResultDto<DealItemDto>> GetDealItemAsync(DealItemFilterDto filterDto);
        Task<DealItemDto?> GetByIdAsync(Guid id);
        Task<DealItemDto> CreateAsync(CreateDealItemDto dto);
        Task<bool> RemoveAsync(Guid id);
        Task<bool> UpdateQuantityAsync(DealItemUpdateQuantityDto dto);
        Task<bool> ChangeProductAsync(DealItemChangeProductDto dto);
    }
}
