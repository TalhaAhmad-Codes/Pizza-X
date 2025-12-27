using PizzaX.Domain.Orders.Enums;

namespace PizzaX.ApplicationCore.DTOs.OrderDTOs
{
    public sealed class CreateOrderDto
    {
        public int UserId { get; init; }
        public PaymentMethod PaymentMethod { get; init; }
        public IReadOnlyList<CreateOrderItemDto> itemDtos { get; init; }

        // Delivery Info
        public string CustomerName { get; init; }
        public string Address { get; init; }
        public string City { get; init; }
        public string Phone { get; init; }
    }
}
