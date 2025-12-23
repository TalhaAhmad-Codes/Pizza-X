using PizzaX.ApplicationCore.DTOs.Common;
using PizzaX.Domain.Orders.Enums;

namespace PizzaX.ApplicationCore.DTOs.OrderDTOs
{
    public sealed class OrderDto : AuditableDto
    {
        public int UserId { get; init; }
        public string OrderNumber { get; init; }
        public OrderStatus OrderStatus { get; init; }
        public PaymentStatus PaymentStatus { get; init; }
        public PaymentMethod PaymentMethod { get; init; }
        public decimal TotalAmount { get; init; }

        // Delivery Info
        public string CustomerName { get; init; }
        public string Address { get; init; }
        public string City { get; init; }
        public string Phone { get; init; }
    }
}
