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
                FriesCategoryId = fries.FriesCategoryId,
                UnitPrice = fries.Price.UnitPrice,
                TotalPrice = fries.TotalPrice,
                Quantity = fries.Quantity.Value,
                Description = fries.Description,
                CreatedAt = fries.CreatedAt,
                UpdatedAt = fries.UpdatedAt
            };
    }
}
