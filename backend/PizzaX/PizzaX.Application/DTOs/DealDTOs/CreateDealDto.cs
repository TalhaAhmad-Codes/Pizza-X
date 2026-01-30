namespace PizzaX.Application.DTOs.DealDTOs
{
    public sealed class CreateDealDto
    {
        public string Name { get; init; }
        public string? Description { get; init; }
        public List<DealItemDto> Items { get; init; }
        public decimal Price { get; init; }
    }
}
