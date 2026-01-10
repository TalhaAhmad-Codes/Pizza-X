using Microsoft.EntityFrameworkCore;
using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.FriesDTOs;
using PizzaX.Application.DTOs.FriesDTOs.FriesUpdateDtos;
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

        public async Task<Fries?> UpdateDescriptionAsync(FriesUpdateDescriptionDto descriptionDto)
        {
            var fries = await GetByIdAsync(descriptionDto.Id);

            if (fries != null)
            {
                fries.UpdateDescription(descriptionDto.Description);
                await UpdateAsync(fries);
            }

            return fries;
        }

        public async Task<Fries?> UpdateImageAsync(FriesUpdateImageDto imageDto)
        {
            var fries = await GetByIdAsync(imageDto.Id);

            if (fries != null)
            {
                fries.UpdateImage(imageDto.Image);
                await UpdateAsync(fries);
            }

            return fries;
        }

        public async Task<Fries?> UpdatePriceAsync(FriesUpdatePriceDto priceDto)
        {
            var fries = await GetByIdAsync(priceDto.Id);

            if (fries != null)
            {
                fries.UpdatePrice(priceDto.Price);
                await UpdateAsync(fries);
            }

            return fries;
        }

        public async Task<Fries?> UpdateQuantityAsync(FriesUpdateQuantityDto quantityDto)
        {
            var fries = await GetByIdAsync(quantityDto.Id);

            if (fries != null)
            {
                fries.UpdateQuantity(quantityDto.Quantity);
                await UpdateAsync(fries);
            }

            return fries;
        }
    }
}
