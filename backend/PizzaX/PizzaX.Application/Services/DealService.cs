using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.DealDTOs;
using PizzaX.Application.DTOs.DealDTOs.DealUpdateDtos;
using PizzaX.Application.Interfaces.Repositories;
using PizzaX.Application.Interfaces.Services;
using PizzaX.Application.Mappers;
using PizzaX.Domain.Common;
using PizzaX.Domain.Entities;
using PizzaX.Domain.ValueObjects.Deal;

namespace PizzaX.Application.Services
{
    public sealed class DealService : IDealService
    {
        private readonly IDealRepository repository;

        public DealService(IDealRepository repository)
            => this.repository = repository;

        public async Task<bool> AddDealItemAsync(DealAddDealItemDto dto)
        {
            var deal = await repository.GetByIdAsync(dto.Id);

            if (deal is null) return false;

            for (int i = 0; i < dto.Items.Count; i++)
            {
                var item = dto.Items[i];

                // If duplicate item found
                if (await repository.GetDealItemAsync(deal, item) != null)
                    continue;

                deal.AddDealItem(
                    productId: item.ProductId,
                    name: item.Name,
                    quantity: item.Quantity
                );
            }
            await repository.UpdateAsync(deal);
            return true;
        }

        public async Task<DealDto> CreateAsync(CreateDealDto dto)
        {
            var deal = Deal.Create(
                name: dto.Name,
                description: dto.Description,
                price: dto.Price
            );

            await repository.AddAsync(deal);
            return DealMapper.ToDto(deal);
        }

        public async Task<PagedResultDto<DealDto>> GetAllAsync(DealFilterDto filterDto)
        {
            var result = await repository.GetAllAsync(filterDto);
            return new PagedResultDto<DealDto>
            {
                Items = result.Items.Select(DealMapper.ToDto).ToList(),
                TotalCount = result.TotalCount
            };
        }

        public async Task<DealDto?> GetByIdAsync(Guid id)
        {
            var deal = await repository.GetByIdAsync(id);
            return deal is null ? null : DealMapper.ToDto(deal);
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var deal = await repository.GetByIdAsync(id);

            if (deal is null) return false;

            await repository.RemoveAsync(deal);
            return true;
        }

        public async Task<bool> RemoveDealItemAsync(DealRemoveDealItemDto dto)
        {
            // Getting deal object
            var deal = await repository.GetByIdAsync(dto.Id);

            if (deal is null) return false;
            
            // Getting deal item object
            var item = await repository.GetDealItemAsync(deal, dto.Item);
            
            if (item is null) return false;

            deal.RemoveDealItem(item);
            await repository.UpdateAsync(deal);
            return true;
        }

        public async Task<bool> UpdateDescriptionAsync(DealUpdateDescriptionDto dto)
        {
            var deal = await repository.GetByIdAsync(dto.Id);

            if (deal is null) return false;

            deal.UpdateDescription(dto.Description);
            await repository.UpdateAsync(deal);
            return true;
        }

        public async Task<bool> UpdateNameAsync(DealUpdateNameDto dto)
        {
            var deal = await repository.GetByIdAsync(dto.Id);

            if (deal is null) return false;

            deal.UpdateName(dto.Name);
            await repository.UpdateAsync(deal);
            return true;
        }
    }
}
