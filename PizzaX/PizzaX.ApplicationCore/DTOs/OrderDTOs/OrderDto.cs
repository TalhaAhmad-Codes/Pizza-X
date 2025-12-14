using PizzaX.ApplicationCore.DTOs.Common;
using PizzaX.Domain.Orders.Enums;
using PizzaX.Domain.Orders.ValueObjects;

namespace PizzaX.ApplicationCore.DTOs.OrderDTOs
{
    public sealed class OrderDto : AuditableDto
    {
        public OrderNumber OrderNumber { get; init; } = default!;
        public OrderStatus OrderStatus { get; init; }
        public PaymentStatus PaymentStatus { get; init; }
        public PaymentMethod PaymentMethod { get; init; }
        public decimal TotalAmount { get; init; }
    }
}
