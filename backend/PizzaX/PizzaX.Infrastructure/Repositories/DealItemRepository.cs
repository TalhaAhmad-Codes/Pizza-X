using Microsoft.EntityFrameworkCore;
using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.DealItemDTOs;
using PizzaX.Application.Interfaces.Repositories;
using PizzaX.Domain.Entities;
using PizzaX.Infrastructure.Data;

namespace PizzaX.Infrastructure.Repositories
{
    public sealed class DealItemRepository : GeneralRepository<DealItem>, IDealItemRepository
    {
        public DealItemRepository(PizzaXDbContext context) : base(context) { }

        public async Task<PagedResultDto<DealItem>> GetAllDealItemsAsync(DealItemFilterDto filterDto)
        {
            var query = dbSet.AsQueryable();

            if (filterDto.ProductId.HasValue)
                query = query.Where(i => i.ProductId == filterDto.ProductId);

            if (filterDto.DealId.HasValue)
                query = query.Where(i => i.DealId == filterDto.DealId);

            if (filterDto.MinQuantity.HasValue)
                query = query.Where(i => i.Quantity >= filterDto.MinQuantity.Value);

            if (filterDto.MaxQuantity.HasValue)
                query = query.Where(i => i.Quantity <= filterDto.MaxQuantity.Value);

            var totalCount = await query.CountAsync();
            var items = await GetPagedResultItemsAsync(query, filterDto.PageNumber, filterDto.PageSize);

            return new PagedResultDto<DealItem>()
            {
                Items = items,
                TotalCount = totalCount
            };
        }
    }
}
