using PizzaX.Application.DTOs.BaseCategoryDTOs;
using PizzaX.Domain.Entities;

namespace PizzaX.Application.Mappers
{
    public static class CategoryMapper
    {
        public static BaseCategoryDto PizzaVarietyToDto(PizzaVariety variety)
            => new()
            {
                Id = variety.Id,
                Name = variety.Value,
                CreatedAt = variety.CreatedAt,
                UpdatedAt = variety.UpdatedAt
            };

        public static BaseCategoryDto ProductCategoryToDto(ProductCategory category)
            => new()
            {
                Id = category.Id,
                Name = category.Value,
                CreatedAt = category.CreatedAt,
                UpdatedAt = category.UpdatedAt
            };
    }
}
