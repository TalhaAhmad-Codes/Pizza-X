using PizzaX.ApplicationCore.DTOs.Common;
using PizzaX.ApplicationCore.DTOs.OrderDTOs;

namespace PizzaX.ApplicationCore.Interfaces.Services
{
    public interface IOrderService
    {
        Task<OrderDto> PlaceOrderAsync(CreateOrderDto dto);
        Task<OrderDto?> GetOrderAsync(string orderNumber);
        Task<PagedResultDto<OrderDto>> GetOrdersAsync(OrderFilterDto filter);
    }
}
