using PizzaX.Application.DTOs.DealDTOs;
using PizzaX.Application.DTOs.DealItemDTOs;
using PizzaX.Domain.Entities;
using PizzaX.Domain.ValueObjects.Deal;

namespace PizzaX.Application.Mappers
{
    public static class DealMapper
    {
        public static DealDto ToDto(Deal deal)
            => new()
            {
                Id = deal.Id,
                Name = deal.Name,
                Description = deal.Description,
                Items = deal.Items.Select(DealItemMapper.ToDto).ToList(),
                Price = deal.Price.UnitPrice,
                CreatedAt = deal.CreatedAt,
                UpdatedAt = deal.UpdatedAt
            };
    }

    public static class DealItemMapper
    {
        public static DealItemDto ToDto(DealItem dealItem)
            => new()
            {
                //ProductId = dealItem.ProductId,
                Name = dealItem.Name,
                Quantity = dealItem.Quantity.Value
            };


        public static DealItem ToEntity(DealItemDto dto)
            => DealItem.Create(
                productId: dto.ProductId,
                name: dto.Name,
                quantity: dto.Quantity
            );
    }
}
