using PizzaX.Application.DTOs.PizzaDTOs;
using PizzaX.Domain.Entities;

namespace PizzaX.Application.Mappers
{
    public static class PizzaMapper
    {
        public static PizzaDto ToDto(Pizza pizza)
            => new()
            {
                Id = pizza.Id,
                Image = pizza.Image,
                VarietyId = pizza.VarietyId,
                UnitPrice = pizza.Price.UnitPrice,
                TotalPrice = pizza.TotalPrice,
                Quantity = pizza.Quantity.Value,
                StockStatus = pizza.StockStatus,
                Size = pizza.Size,
                Description = pizza.Description,
                CreatedAt = pizza.CreatedAt,
                UpdatedAt = pizza.UpdatedAt
            };
    }
}
