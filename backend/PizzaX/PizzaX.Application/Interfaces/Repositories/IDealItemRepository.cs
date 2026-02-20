using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.DealItemDTOs;
using PizzaX.Domain.Entities;

namespace PizzaX.Application.Interfaces.Repositories
{
    public interface IDealItemRepository : IGeneralRepository<DealItem>
    {
        Task<PagedResultDto<DealItem>> GetAllDealItemsAsync(DealItemFilterDto filterDto);
    }
}
