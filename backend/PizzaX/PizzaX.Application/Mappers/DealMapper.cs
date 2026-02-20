using PizzaX.Application.DTOs.DealDTOs;
using PizzaX.Domain.Entities;

namespace PizzaX.Application.Mappers
{
    public static class DealMapper
    {
        public static DealDto ToDto(Deal deal)
            => new()
            {
                Id = deal.Id,
                Name = deal.Name,
                Description = deal.Description,
                DealItems = deal.DealItems.Select(DealItemMapper.ToDto).ToList(),
                Price = deal.Price.UnitPrice,
                CreatedAt = deal.CreatedAt,
                UpdatedAt = deal.UpdatedAt
            };
    }
}
