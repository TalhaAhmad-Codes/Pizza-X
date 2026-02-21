using PizzaX.Application.DTOs.DealItemDTOs;

namespace PizzaX.Application.DTOs.DealDTOs
{
    public sealed class CreateDealDto
    {
        public string Name { get; init; }
        public string? Description { get; init; }
        public decimal Price { get; init; }
    }
}
