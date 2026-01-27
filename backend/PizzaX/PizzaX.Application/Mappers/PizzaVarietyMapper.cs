using PizzaX.Application.DTOs.BaseCategoryDTOs;
using PizzaX.Domain.Entities;

namespace PizzaX.Application.Mappers
{
    public static class PizzaVarietyMapper
    {
        public static BaseCategoryDto ToDto(PizzaVariety variety)
            => new()
            {
                Id = variety.Id,
                Name = variety.Value,
                CreatedAt = variety.CreatedAt,
                UpdatedAt = variety.UpdatedAt
            };
    }
}
