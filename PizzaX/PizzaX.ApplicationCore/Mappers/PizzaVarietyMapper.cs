using PizzaX.ApplicationCore.DTOs.PizzaVarietyDTOs;
using PizzaX.Domain.Pizzas.Entities;

namespace PizzaX.ApplicationCore.Mappers
{
    public static class PizzaVarietyMapper
    {
        public static PizzaVarietyDto ToDto(PizzaVariety pizzaVariety)
            => new() {
                Id = pizzaVariety.Id,
                Name = pizzaVariety.Name,
                CreatedAt = pizzaVariety.CreatedAt,
                UpdatedAt = pizzaVariety.UpdatedAt
            };
    }
}
