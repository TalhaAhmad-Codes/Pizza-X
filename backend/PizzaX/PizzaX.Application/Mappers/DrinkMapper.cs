using PizzaX.Application.DTOs.DrinkDTOs;
using PizzaX.Domain.Entities;

namespace PizzaX.Application.Mappers
{
    public static class DrinkMapper
    {
        public static DrinkDto ToDto(Drink drink)
            => new()
            {
                Id = drink.Id,
                Image = drink.Image,
                UnitPrice = drink.Price.UnitPrice,
                TotalPrice = drink.TotalPrice,
                Quantity = drink.Quantity.Value,
                DrinkType = drink.DrinkType,
                CompanyName = drink.DrinkDetails.Company,
                RetailerContactNumber = drink.DrinkDetails.RetailerContactNumber,
                CreatedAt = drink.CreatedAt,
                UpdatedAt = drink.UpdatedAt
            };
    }
}
