using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.DealItemDTOs;
using PizzaX.Application.DTOs.DealItemDTOs.DealItemUpdateDtos;
using PizzaX.Application.Interfaces.Repositories;
using PizzaX.Application.Interfaces.Services;
using PizzaX.Application.Mappers;
using PizzaX.Domain.Entities;

namespace PizzaX.Application.Services
{
    public sealed class DealItemService : IDealItemService
    {
        private readonly IDealItemRepository repository;

        public DealItemService(IDealItemRepository repository)
            => this.repository = repository;

        public async Task<bool> ChangeProductAsync(DealItemChangeProductDto dto)
        {
            var dealItem = await repository.GetByIdAsync(dto.Id);

            if (dealItem is null)
                return false;

            dealItem.ChangeProduct(dto.ProductId);
            await repository.UpdateAsync(dealItem);
            return true;
        }

        public async Task<DealItemDto> CreateAsync(CreateDealItemDto dto)
        {
            var dealItem = DealItem.Create(
                productId: dto.ProductId,
                dealId: dto.DealId,
                quantity: dto.Quantity
            );

            await repository.AddAsync(dealItem);
            return DealItemMapper.ToDto(dealItem);
        }

        public async Task<DealItemDto?> GetByIdAsync(Guid id)
        {
            var dealItem = await repository.GetByIdAsync(id);

            return dealItem is null ? null : DealItemMapper.ToDto(dealItem);
        }

        public async Task<PagedResultDto<DealItemDto>> GetDealItemAsync(DealItemFilterDto filterDto)
        {
            var result = await repository.GetAllDealItemsAsync(filterDto);

            return new PagedResultDto<DealItemDto>()
            {
                Items = result.Items.Select(DealItemMapper.ToDto).ToList(),
                TotalCount = result.TotalCount
            };
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var dealItem = await repository.GetByIdAsync(id);

            if (dealItem is null)
                return false;

            await repository.RemoveAsync(dealItem);
            return true;
        }

        public async Task<bool> UpdateQuantityAsync(DealItemUpdateQuantityDto dto)
        {
            var dealItem = await repository.GetByIdAsync(dto.Id);

            if (dealItem is null)
                return false;

            dealItem.UpdateQuantity(dto.Quantity);
            await repository.UpdateAsync(dealItem);
            return true;
        }
    }
}
