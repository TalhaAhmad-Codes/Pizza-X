using PizzaX.ApplicationCore.DTOs.Common;

namespace PizzaX.ApplicationCore.DTOs.OrderDTOs
{
    public sealed class CreateOrderDto
    {
        public int UserId { get; init; }
        public IReadOnlyList<CreateOrderItemDto> itemDtos { get; init; } = [];
    }
}
