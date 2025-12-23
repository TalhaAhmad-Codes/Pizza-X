using PizzaX.ApplicationCore.DTOs.OrderDTOs;
using PizzaX.Domain.Orders.Entities;

namespace PizzaX.ApplicationCore.Mappers
{
    public static class OrderMapper
    {
        public static OrderDto ToDto(Order order)
            => new() { 
                Id = order.Id,
                UserId = order.UserId,
                OrderNumber = order.OrderNumber.Value,
                OrderStatus = order.Status,
                PaymentStatus = order.PaymentStatus,
                PaymentMethod = order.PaymentMethod,
                TotalAmount = order.TotalPrice,
                CustomerName = order.DeliveryInfo.CustomerName,
                Address = order.DeliveryInfo.Address,
                City = order.DeliveryInfo.City,
                Phone = order.DeliveryInfo.Phone,
                CreatedAt = order.CreatedAt,
                UpdatedAt = order.UpdatedAt
            };
    }
}
