using PizzaX.Application.DTOs.PizzaVarietyDTOs;
using PizzaX.Domain.Entities;

namespace PizzaX.Application.Mappers
{
    public static class PizzaVarietyMapper
    {
        public static PizzaVarietyDto ToDto(PizzaVariety variety)
            => new()
            {
                Id = variety.Id,
                Name = variety.Name,
                CreatedAt = variety.CreatedAt,
                UpdatedAt = variety.UpdatedAt
            };
    }
}
