using PizzaX.Application.DTOs.FriesCetagoryDTOs;
using PizzaX.Domain.Entities;

namespace PizzaX.Application.Mappers
{
    public static class FriesCategoryMapper
    {
        public static FriesCategoryDto ToDto(FriesCategory category)
            => new()
            {
                Id = category.Id,
                Name = category.Name,
                CreatedAt = category.CreatedAt,
                UpdatedAt = category.UpdatedAt
            };
    }
}
