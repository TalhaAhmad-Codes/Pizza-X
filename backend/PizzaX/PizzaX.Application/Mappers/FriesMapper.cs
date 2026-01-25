using PizzaX.Application.DTOs.FriesDTOs;
using PizzaX.Domain.Entities;

namespace PizzaX.Application.Mappers
{
    public static class FriesMapper
    {
        public static FriesDto ToDto(Fries fries)
            => new()
            {
                Id = fries.Id,
                Image = fries.Image,
                Category = fries.Category,
                UnitPrice = fries.Price.UnitPrice,
                TotalPrice = fries.TotalPrice,
                Quantity = fries.Quantity.Value,
                StockStatus = fries.StockStatus,
                Description = fries.Description,
                CreatedAt = fries.CreatedAt,
                UpdatedAt = fries.UpdatedAt
            };
    }
}
