using PizzaX.ApplicationCore.DTOs.Common;
using PizzaX.Domain.Orders.Enums;

namespace PizzaX.ApplicationCore.DTOs.OrderDTOs
{
    public sealed class OrderFilterDto : BaseFilterDto
    {
        public OrderStatus? Status { get; init; }
        public PaymentStatus? PaymentStatus { get; init; }
        public int? UserId { get; init; }
        public DateTime? FromDate { get; init; }
        public DateTime? ToDate { get; init; }
    }
}
