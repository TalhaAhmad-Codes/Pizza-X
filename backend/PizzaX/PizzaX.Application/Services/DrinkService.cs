using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.DrinkDTOs;
using PizzaX.Application.DTOs.DrinkDTOs.DrinkUpdateDtos;
using PizzaX.Application.DTOs.ProductDTOs.BaseProductUpdateDtos;
using PizzaX.Application.Interfaces.Repositories;
using PizzaX.Application.Interfaces.Services;
using PizzaX.Application.Mappers;

namespace PizzaX.Application.Services
{
    public sealed class DrinkService : IDrinkService
    {
        private readonly IDrinkRepository repository;

        public DrinkService(IDrinkRepository repository)
            => this.repository = repository;

        public async Task<PagedResultDto<DrinkDto>> GetAllAsync(DrinkFilterDto filterDto)
        {
            var result = await repository.GetAllAsync(filterDto);

            return new PagedResultDto<DrinkDto>
            {
                Items = result.Items.Select(DrinkMapper.ToDto).ToList(),
                TotalCount = result.TotalCount
            };
        }

        public async Task<bool> UpdateCompanyDetailsAsync(DrinkUpdateDetailsCompanyNameDto dto)
        {
            var drink = await repository.GetByIdAsync(dto.Id);

            if (drink is null) return false;

            drink.UpdateDrinkDetailsCompanyName(dto.CompanyName);
            await repository.UpdateAsync(drink);
            return true;
        }

        public async Task<bool> UpdateDescriptionAsync(ProductUpdateDescriptionDto dto)
        {
            var drink = await repository.GetByIdAsync(dto.Id);

            if (drink is null) return false;

            drink.UpdateDescription(dto.Description);
            await repository.UpdateAsync(drink);
            return true;
        }

        public async Task<bool> UpdateImageAsync(ProductUpdateImageDto dto)
        {
            var drink = await repository.GetByIdAsync(dto.Id);

            if (drink is null) return false;

            drink.UpdateImage(dto.Image);
            await repository.UpdateAsync(drink);
            return true;
        }

        public async Task<bool> UpdatePriceAsync(ProductUpdatePriceDto dto)
        {
            var drink = await repository.GetByIdAsync(dto.Id);

            if (drink is null) return false;

            drink.UpdatePrice(dto.Price);
            await repository.UpdateAsync(drink);
            return true;
        }

        public async Task<bool> UpdateQuantityAsync(ProductUpdateQuantityDto dto)
        {
            var drink = await repository.GetByIdAsync(dto.Id);

            if (drink is null) return false;

            drink.UpdateQuantity(dto.Quantity);
            await repository.UpdateAsync(drink);
            return true;
        }

        public async Task<bool> UpdateRetailerNumberAsync(DrinkUpdateDetailsRetailerContactNumber dto)
        {
            var drink = await repository.GetByIdAsync(dto.Id);

            if (drink is null) return false;

            drink.UpdateDrinkDetailsRetailerContactNumber(dto.RetailerContactNumber);
            await repository.UpdateAsync(drink);
            return true;
        }
    }
}
