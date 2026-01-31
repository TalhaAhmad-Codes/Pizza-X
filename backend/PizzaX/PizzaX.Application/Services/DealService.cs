using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.DealDTOs;
using PizzaX.Application.DTOs.DealDTOs.DealUpdateDtos;
using PizzaX.Application.Interfaces.Repositories;
using PizzaX.Application.Interfaces.Services;
using PizzaX.Application.Mappers;
using PizzaX.Domain.Common;
using PizzaX.Domain.Entities;

namespace PizzaX.Application.Services
{
    public sealed class DealService : IDealService
    {
        private readonly IDealRepository repository;

        public DealService(IDealRepository repository)
            => this.repository = repository;

        public async Task<bool> AddDealPizzaItemAsync(DealAddDealItemsDto dto)
        {
            var deal = await repository.GetByIdAsync(dto.Id);

            if (deal is null) return false;

            for (int i = 0; i < dto.Items.Count; i++)
            {
                var item = dto.Items[i];
                var pizza = await repository.GetPizzaByIdAsync(item.ProductId)
                    ?? throw new DomainException($"There's no pizza exists of Id {item.ProductId}.");

                deal.AddDealItem(item.ProductId, item.Name, item.Quantity);
            }

            await repository.UpdateAsync(deal);
            return true;
        }

        public async Task<bool> AddDealProductItemAsync(DealAddDealItemsDto dto)
        {
            var deal = await repository.GetByIdAsync(dto.Id);

            if (deal is null) return false;

            for (int i = 0; i < dto.Items.Count; i++)
            {
                var item = dto.Items[i];
                var product = await repository.GetProductByIdAsync(item.ProductId)
                    ?? throw new DomainException($"There's no product exists of Id {item.ProductId}.");

                deal.AddDealItem(item.ProductId, item.Name, item.Quantity);
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

        public async Task<bool> RemoveDealPizzaItemAsync(DealRemoveDealItemDto dto)
        {
            var deal = await repository.GetByIdAsync(dto.Id);

            if (deal is null) return false;

            var pizza = await repository.GetPizzaByIdAsync(dto.Item.ProductId)
                ?? throw new DomainException($"There's no product exists of Id {dto.Item.ProductId}.");

            deal.RemoveDealItem(DealItemMapper.ToEntity(dto.Item));
            await repository.UpdateAsync(deal);
            return true;
        }

        public async Task<bool> RemoveDealProductItemAsync(DealRemoveDealItemDto dto)
        {
            var deal = await repository.GetByIdAsync(dto.Id);

            if (deal is null) return false;

            var product = await repository.GetProductByIdAsync(dto.Item.ProductId)
                ?? throw new DomainException($"There's no product exists of Id {dto.Item.ProductId}.");

            deal.RemoveDealItem(DealItemMapper.ToEntity(dto.Item));
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

        public async Task<bool> UpdatePriceAsync(DealUpdatePriceDto dto)
        {
            var deal = await repository.GetByIdAsync(dto.Id);

            if (deal is null) return false;

            deal.UpdatePrice(dto.Price);
            await repository.UpdateAsync(deal);
            return true;
        }
    }
}
