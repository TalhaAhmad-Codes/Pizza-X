using PizzaX.Application.DTOs.DealItemDTOs;
using PizzaX.Domain.Entities;

namespace PizzaX.Application.Mappers
{
    public static class DealItemMapper
    {
        public static DealItemDto ToDto(DealItem dealItem)
            => new()
            {
                Id = dealItem.Id,
                ProductId = dealItem.ProductId,
                DealId = dealItem.DealId,
                Quantity = dealItem.Quantity.Value,
                CreatedAt = dealItem.CreatedAt,
                UpdatedAt = dealItem.UpdatedAt
            };
    }
}
