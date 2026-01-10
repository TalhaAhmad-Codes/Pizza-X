using Microsoft.EntityFrameworkCore;
using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.DrinkDTOs;
using PizzaX.Application.DTOs.DrinkDTOs.DrinkUpdateDtos;
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
                query = query.Where(d => d.DrinkDetails.Company.ToLower() == filterDto.CompanyName.ToLower());

            if (filterDto.RetailerContactNumber != null)
                query = query.Where(d => d.DrinkDetails.RetailerContactNumber!.ToLower() == filterDto.RetailerContactNumber.ToLower());

            if (filterDto.MinPrice.HasValue)
                query = query.Where(d => d.Price.UnitPrice >= filterDto.MinPrice);

            if (filterDto.MaxPrice.HasValue)
                query = query.Where(d => d.Price.UnitPrice <= filterDto.MaxPrice);

            if (filterDto.MinQuantity.HasValue)
                query = query.Where(d => d.Quantity.Value >= filterDto.MinQuantity);

            if (filterDto.MaxQuantity.HasValue)
                query = query.Where(d => d.Quantity.Value <= filterDto.MaxQuantity);

            // Getting paged result
            var totalCount = await query.CountAsync();
            var items = await GetPagedResultItemsAsync(query, filterDto.PageNumber, filterDto.PageSize);

            return new PagedResultDto<Drink> 
            {
                Items = items,
                TotalCount = totalCount
            };
        }

        public async Task<Drink?> UpdateDescriptionAsync(DrinkUpdateDescriptionDto descriptionDto)
        {
            var drink = await GetByIdAsync(descriptionDto.Id);

            if (drink != null)
            {
                drink.UpdateDescription(descriptionDto.Description);
                await UpdateAsync(drink);
            }

            return drink;
        }

        public async Task<Drink?> UpdateImageAsync(DrinkUpdateImageDto imageDto)
        {
            var drink = await GetByIdAsync(imageDto.Id);

            if (drink != null)
            {
                drink.UpdateImage(imageDto.Image);
                await UpdateAsync(drink);
            }

            return drink;
        }

        public async Task<Drink?> UpdatePriceAsync(DrinkUpdatePriceDto priceDto)
        {
            var drink = await GetByIdAsync(priceDto.Id);

            if (drink != null)
            {
                drink.UpdatePrice(priceDto.Price);
                await UpdateAsync(drink);
            }

            return drink;
        }

        public async Task<Drink?> UpdateQuantityAsync(DrinkUpdateQuantityDto quantityDto)
        {
            var drink = await GetByIdAsync(quantityDto.Id);

            if (drink != null)
            {
                drink.UpdateQuantity(quantityDto.Quantity);
                await UpdateAsync(drink);
            }

            return drink;
        }

        public async Task<Drink?> UpdateDetailsCompanyNameAsync(DrinkUpdateDetailsCompanyNameDto companyNameDto)
        {
            var drink = await GetByIdAsync(companyNameDto.Id);

            if (drink != null)
            {
                drink.UpdateDrinkDetailsCompanyName(companyNameDto.CompanyName);
                await UpdateAsync(drink);
            }

            return drink;
        }

        public async Task<Drink?> UpdateDetailsRetailerContactNumberAsync(DrinkUpdateDetailsRetailerContactNumber numberDto)
        {
            var drink = await GetByIdAsync(numberDto.Id);

            if (drink != null)
            {
                drink.UpdateDrinkDetailsRetailerContactNumber(numberDto.RetailerContactNumber);
                await UpdateAsync(drink);
            }

            return drink;
        }
    }
}
