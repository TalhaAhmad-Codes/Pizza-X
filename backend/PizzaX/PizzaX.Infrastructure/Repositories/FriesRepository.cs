using Microsoft.EntityFrameworkCore;
using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.FriesDTOs;
using PizzaX.Application.Interfaces.Repositories;
using PizzaX.Domain.Entities;
using PizzaX.Infrastructure.Data;

namespace PizzaX.Infrastructure.Repositories
{
    public sealed class FriesRepository : GeneralRepository<Fries>, IFriesRepository
    {
        public FriesRepository(PizzaXDbContext dbContext) : base(dbContext) { }

        public async Task<PagedResultDto<Fries>> GetAllAsync(FriesFilterDto filterDto)
        {
            var query = dbSet.AsQueryable();

            // Applying filters
            if (filterDto.FriesCetagoryId.HasValue)
                query = query.Where(f => f.FriesCategoryId == filterDto.FriesCetagoryId);

            if (filterDto.MinPrice.HasValue)
                query = query.Where(f => f.Price.UnitPrice >= filterDto.MinPrice);

            if (filterDto.MaxPrice.HasValue)
                query = query.Where(f => f.Price.UnitPrice <= filterDto.MaxPrice);

            if (filterDto.MinQuantity.HasValue)
                query = query.Where(f => f.Quantity.Value >= filterDto.MinQuantity);

            if (filterDto.MaxQuantity.HasValue)
                query = query.Where(f => f.Quantity.Value <= filterDto.MaxQuantity);

            // Getting paged result
            var totalCount = await query.CountAsync();
            var items = await GetPagedResultItemsAsync(query, filterDto.PageNumber, filterDto.PageSize);

            return new PagedResultDto<Fries>
            {
                Items = items,
                TotalCount = totalCount
            };
        }
    }
}
