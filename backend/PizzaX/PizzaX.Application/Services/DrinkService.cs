using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.DrinkDTOs;
using PizzaX.Application.DTOs.DrinkDTOs.DrinkUpdateDtos;
using PizzaX.Application.DTOs.ProductDTOs.BaseProductUpdateDtos;
using PizzaX.Application.Interfaces.Repositories;
using PizzaX.Application.Interfaces.Services;
using PizzaX.Application.Mappers;
using PizzaX.Domain.Entities;

namespace PizzaX.Application.Services
{
    public sealed class DrinkService : IDrinkService
    {
        private readonly IDrinkRepository repository;

        public DrinkService(IDrinkRepository repository)
            => this.repository = repository;

        public async Task<DrinkDto> CreateAsync(CreateDrinkDto dto)
        {
            var drink = Drink.Create(
                image: dto.Image,
                unitPrice: dto.UnitPrice,
                quantity: dto.Quantity,
                description: dto.Description,
                drinkType: dto.DrinkType,
                companyName: dto.CompanyName,
                retailerContactNumber: dto.RetailerContactNumber
            );

            await repository.AddAsync(drink);
            return DrinkMapper.ToDto(drink);
        }

        public async Task<PagedResultDto<DrinkDto>> GetAllAsync(DrinkFilterDto filterDto)
        {
            var result = await repository.GetAllAsync(filterDto);

            return new PagedResultDto<DrinkDto>
            {
                Items = result.Items.Select(DrinkMapper.ToDto).ToList(),
                TotalCount = result.TotalCount
            };
        }

        public async Task<DrinkDto?> GetByIdAsync(Guid id)
        {
            var drink = await repository.GetByIdAsync(id);

            return drink is null ? null : DrinkMapper.ToDto(drink);
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var drink = await repository.GetByIdAsync(id);

            if (drink is null) return false;

            await repository.RemoveAsync(drink);
            return true;
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
