namespace PizzaX.Application.DTOs.DealItemDTOs
{
    public sealed class CreateDealItemDto
    {
        public Guid ProductId { get; init; }
        public Guid DealId { get; init; }
        public int Quantity { get; init; }
    }
}
