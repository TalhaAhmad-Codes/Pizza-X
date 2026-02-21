using Microsoft.EntityFrameworkCore;
using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.DealDTOs;
using PizzaX.Application.Interfaces.Repositories;
using PizzaX.Domain.Common;
using PizzaX.Domain.Entities;
using PizzaX.Infrastructure.Data;

namespace PizzaX.Infrastructure.Repositories
{
    public sealed class DealRepository : GeneralRepository<Deal>, IDealRepository
    {
        public DealRepository(PizzaXDbContext context) : base(context) { }

        public async Task<PagedResultDto<Deal>> GetAllAsync(DealFilterDto filterDto)
        {
            var query = dbSet.AsQueryable();

            if (filterDto.DealItemId.HasValue)
                query = query.Where(d => d.DealItems.Any(i => i.Id == filterDto.DealItemId));

            if (filterDto.Name != null)
                query = query.Where(d => d.Name == Function.Simplify(filterDto.Name, true));

            if (filterDto.MinPrice.HasValue)
                query = query.Where(d => d.Price >= filterDto.MinPrice.Value);

            if (filterDto.MaxPrice.HasValue)
                query = query.Where(d => d.Price <= filterDto.MaxPrice.Value);

            var totalCount = await query.CountAsync();
            var items = await GetPagedResultItemsAsync(query, filterDto.PageNumber, filterDto.PageSize);

            return new PagedResultDto<Deal>
            {
                Items = items,
                TotalCount = totalCount
            };
        }
    }
}
