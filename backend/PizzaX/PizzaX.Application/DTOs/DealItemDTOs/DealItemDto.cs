using PizzaX.Application.DTOs.Common;

namespace PizzaX.Application.DTOs.DealItemDTOs
{
    public sealed class DealItemDto : BaseAuditableDto
    {
        public Guid ProductId { get; init; }
        public Guid DealId { get; init; }
        public int Quantity { get; init; }
    }
}
