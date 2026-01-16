using Microsoft.EntityFrameworkCore;
using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.PizzaDTOs;
using PizzaX.Application.Interfaces.Repositories;
using PizzaX.Domain.Entities;
using PizzaX.Domain.Enums.Pizza;
using PizzaX.Infrastructure.Data;

namespace PizzaX.Infrastructure.Repositories
{
    public sealed class PizzaRepository : GeneralRepository<Pizza>, IPizzaRepository
    {
        public PizzaRepository(PizzaXDbContext dbContext) : base(dbContext) { }

        public async Task<bool> ExistsBySizeAndVariety(Size size, Guid varietyId)
        {
            var result = await GetAllAsync(new()
            {
                Size = size, VarietyId = varietyId
            });

            return result.TotalCount > 0;
        }

        public async Task<PagedResultDto<Pizza>> GetAllAsync(PizzaFilterDto filterDto)
        {
            var query = dbSet.AsQueryable();

            // Applying filters
            if (filterDto.VarietyId.HasValue)
                query = query.Where(p => p.VarietyId == filterDto.VarietyId);

            if (filterDto.Size.HasValue)
                query = query.Where(p => p.Size == filterDto.Size);

            if (filterDto.MinPrice.HasValue)
                query = query.Where(p => p.Price.UnitPrice >= filterDto.MinPrice);

            if (filterDto.MaxPrice.HasValue)
                query = query.Where(p => p.Price.UnitPrice <= filterDto.MaxPrice);

            if (filterDto.MinQuantity.HasValue)
                query = query.Where(p => p.Quantity.Value >= filterDto.MinQuantity);

            if (filterDto.MaxQuantity.HasValue)
                query = query.Where(p => p.Quantity.Value <= filterDto.MaxQuantity);

            if (filterDto.StockStatus.HasValue)
                query = query.Where(p => p.StockStatus == filterDto.StockStatus);

            // Getting pages result
            var totalCount = await query.CountAsync();
            var items = await GetPagedResultItemsAsync(query, filterDto.PageNumber, filterDto.PageSize);

            return new PagedResultDto<Pizza>
            {
                Items = items,
                TotalCount = totalCount
            };
        }
    }
}
