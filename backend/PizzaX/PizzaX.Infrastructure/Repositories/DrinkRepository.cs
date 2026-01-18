using Microsoft.EntityFrameworkCore;
using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.DrinkDTOs;
using PizzaX.Application.Interfaces.Repositories;
using PizzaX.Domain.Entities;
using PizzaX.Infrastructure.Data;

namespace PizzaX.Infrastructure.Repositories
{
    public sealed class DrinkRepository : GeneralRepository<Drink>, IDrinkRepository
    {
        public DrinkRepository(PizzaXDbContext dbContext) : base(dbContext) { }

        public async Task<PagedResultDto<Drink>> GetAllAsync(DrinkFilterDto filterDto)
        {
            var query = dbSet.AsQueryable();

            // Applying filters
            if (filterDto.DrinkType.HasValue)
                query = query.Where(d => d.DrinkType == filterDto.DrinkType);

            if (filterDto.CompanyName != null)
                query = query.Where(d => d.DrinkDetails.Company == filterDto.CompanyName.Trim().ToLower());

            if (filterDto.RetailerContactNumber != null)
                query = query.Where(d => d.DrinkDetails.RetailerContactNumber!.Value == filterDto.RetailerContactNumber.Trim());

            if (filterDto.MinPrice.HasValue)
                query = query.Where(d => d.Price.UnitPrice >= filterDto.MinPrice);

            if (filterDto.MaxPrice.HasValue)
                query = query.Where(d => d.Price.UnitPrice <= filterDto.MaxPrice);

            if (filterDto.MinQuantity.HasValue)
                query = query.Where(d => d.Quantity.Value >= filterDto.MinQuantity);

            if (filterDto.MaxQuantity.HasValue)
                query = query.Where(d => d.Quantity.Value <= filterDto.MaxQuantity);

            if (filterDto.StockStatus.HasValue)
                query = query.Where(d => d.StockStatus == filterDto.StockStatus);

            // Getting paged result
            var totalCount = await query.CountAsync();
            var items = await GetPagedResultItemsAsync(query, filterDto.PageNumber, filterDto.PageSize);

            return new PagedResultDto<Drink> 
            {
                Items = items,
                TotalCount = totalCount
            };
        }
    }
}
