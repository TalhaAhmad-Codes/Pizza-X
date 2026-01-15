using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.FriesDTOs;
using PizzaX.Application.DTOs.ProductDTOs.BaseProductUpdateDtos;
using PizzaX.Application.Interfaces.Repositories;
using PizzaX.Application.Interfaces.Services;
using PizzaX.Application.Mappers;

namespace PizzaX.Application.Services
{
    public sealed class FriesService : IFriesService
    {
        private readonly IFriesRepository repository;

        public FriesService(IFriesRepository repository) 
            => this.repository = repository;

        public async Task<PagedResultDto<FriesDto>> GetAllAsync(FriesFilterDto filterDto)
        {
            var result = await repository.GetAllAsync(filterDto);

            return new PagedResultDto<FriesDto>
            {
                Items = result.Items.Select(FriesMapper.ToDto).ToList(),
                TotalCount = result.TotalCount
            };
        }

        public async Task<bool> UpdateDescriptionAsync(ProductUpdateDescriptionDto dto)
        {
            var fries = await repository.GetByIdAsync(dto.Id);

            if (fries is null) return false;

            fries.UpdateDescription(dto.Description);
            await repository.UpdateAsync(fries);
            return true;
        }

        public async Task<bool> UpdateImageAsync(ProductUpdateImageDto dto)
        {
            var fries = await repository.GetByIdAsync(dto.Id);

            if (fries is null) return false;

            fries.UpdateImage(dto.Image);
            await repository.UpdateAsync(fries);
            return true;
        }

        public async Task<bool> UpdatePriceAsync(ProductUpdatePriceDto dto)
        {
            var fries = await repository.GetByIdAsync(dto.Id);

            if (fries is null) return false;

            fries.UpdatePrice(dto.Price);
            await repository.UpdateAsync(fries);
            return true;
        }

        public async Task<bool> UpdateQuantityAsync(ProductUpdateQuantityDto dto)
        {
            var fries = await repository.GetByIdAsync(dto.Id);

            if (fries is null) return false;

            fries.UpdateQuantity(dto.Quantity);
            await repository.UpdateAsync(fries);
            return true;
        }
    }
}
