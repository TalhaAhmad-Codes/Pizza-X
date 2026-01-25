using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.PizzaDTOs;
using PizzaX.Application.DTOs.ProductDTOs.BaseProductUpdateDtos;
using PizzaX.Application.Interfaces.Repositories;
using PizzaX.Application.Interfaces.Services;
using PizzaX.Application.Mappers;
using PizzaX.Domain.Common;
using PizzaX.Domain.Entities;

namespace PizzaX.Application.Services
{
    public sealed class PizzaService : IPizzaService
    {
        private readonly IPizzaRepository repository;

        public PizzaService(IPizzaRepository repository)
            => this.repository = repository;

        public async Task<PizzaDto> CreateAsync(CreatePizzaDto dto)
        {
            // Rule: Pizzas of both same size and variety can't co-exist
            if (await repository.ExistsBySizeAndVariety(dto.Size, dto.VarietyId))
                throw new DomainException("The pizza of same size and variety already exists.");

            var pizza = Pizza.Create(
                image: dto.Image,
                unitPrice: dto.UnitPrice,
                quantity: dto.Quantity,
                description: dto.Description,
                size: dto.Size,
                varietyId: dto.VarietyId
            );

            await repository.AddAsync(pizza);
            return PizzaMapper.ToDto(pizza);
        }

        public async Task<PagedResultDto<PizzaDto>> GetAllAsync(PizzaFilterDto filterDto)
        {
            var result = await repository.GetAllAsync(filterDto);

            return new PagedResultDto<PizzaDto>
            {
                Items = result.Items.Select(PizzaMapper.ToDto).ToList(),
                TotalCount = result.TotalCount
            };
        }

        public async Task<PizzaDto?> GetByIdAsync(Guid id)
        {
            var pizza = await repository.GetByIdAsync(id);

            return pizza is null ? null : PizzaMapper.ToDto(pizza);
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var pizza = await repository.GetByIdAsync(id);

            if (pizza is null) return false;

            await repository.RemoveAsync(pizza);
            return true;
        }

        public async Task<bool> UpdateDescriptionAsync(ProductUpdateDescriptionDto dto)
        {
            var pizza = await repository.GetByIdAsync(dto.Id);

            if (pizza is null) return false;

            pizza.UpdateDescription(dto.Description);
            await repository.UpdateAsync(pizza);
            return true;
        }

        public async Task<bool> UpdateImageAsync(ProductUpdateImageDto dto)
        {
            var pizza = await repository.GetByIdAsync(dto.Id);

            if (pizza is null) return false;

            pizza.UpdateImage(dto.Image);
            await repository.UpdateAsync(pizza);
            return true;
        }

        public async Task<bool> UpdatePriceAsync(ProductUpdatePriceDto dto)
        {
            var pizza = await repository.GetByIdAsync(dto.Id);

            if (pizza is null) return false;

            pizza.UpdatePrice(dto.Price);
            await repository.UpdateAsync(pizza);
            return true;
        }

        public async Task<bool> UpdateQuantityAsync(ProductUpdateQuantityDto dto)
        {
            var pizza = await repository.GetByIdAsync(dto.Id);

            if (pizza is null) return false;

            pizza.UpdateQuantity(dto.Quantity);
            await repository.UpdateAsync(pizza);
            return true;
        }
    }
}
