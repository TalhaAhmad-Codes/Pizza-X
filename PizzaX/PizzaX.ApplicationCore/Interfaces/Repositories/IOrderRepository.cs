using PizzaX.ApplicationCore.DTOs.Common;
using PizzaX.ApplicationCore.DTOs.OrderDTOs;
using PizzaX.Domain.Orders.Entities;

namespace PizzaX.ApplicationCore.Interfaces.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order?> GetByOrderNumberAsync(string orderNumber);
        Task<PagedResultDto<Order>> GetAsync(OrderFilterDto filter);
    }
}
