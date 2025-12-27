using PizzaX.ApplicationCore.DTOs.PizzaVarietyDTOs;
using PizzaX.Domain.Pizzas.Entities;

namespace PizzaX.ApplicationCore.Factories
{
    public static class PizzaVarietyFactory
    {
        public static PizzaVariety Create(PizzaVarietyDto dto)
            => PizzaVariety.Create(name: dto.Name);
    }
}
