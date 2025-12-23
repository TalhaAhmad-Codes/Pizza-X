using PizzaX.ApplicationCore.DTOs.PizzaDTOs;
using PizzaX.Domain.Pizzas.Entities;

namespace PizzaX.ApplicationCore.Mappers
{
    public static class PizzaMapper
    {
        public static PizzaDto ToDto(Pizza pizza)
            => new() {
                Id = pizza.Id,
                Image = pizza.Image,
                NoOfPizzas = pizza.NoOfPizzas,
                Price = pizza.Price,
                Size = pizza.Size,
                PizzaVarietyId = pizza.PizzaVarietyId,
                Description = pizza.Description,
                CreatedAt = pizza.CreatedAt,
                UpdatedAt = pizza.UpdatedAt
            };
    }
}
