using PizzaX.ApplicationCore.DTOs.Common;
using PizzaX.ApplicationCore.DTOs.OrderDTOs;
using PizzaX.ApplicationCore.Interfaces.Repositories;
using PizzaX.ApplicationCore.Interfaces.Services;
using PizzaX.ApplicationCore.Mappers;

namespace PizzaX.Infrastructure.Services
{
    internal sealed class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IPizzaRepository _pizzaRepository;

        public OrderService(
            IOrderRepository orderRepository,
            IPizzaRepository pizzaRepository)
        {
            _orderRepository = orderRepository;
            _pizzaRepository = pizzaRepository;
        }

        public async Task<OrderDto> PlaceOrderAsync(CreateOrderDto dto)
        {
            // 1. Load pizzas
            // 2. Create Order aggregate
            // 3. Apply domain rules
            // 4. Persist
            // 5. Return mapped DTO

            throw new NotImplementedException();
        }

        public async Task<PagedResultDto<OrderDto>> GetOrdersAsync(OrderFilterDto filter)
        {
            var result = await _orderRepository.GetAsync(filter);

            return new PagedResultDto<OrderDto>
            {
                Items = result.Items.Select(OrderMapper.ToDto).ToList(),
                TotalCount = result.TotalCount
            };
        }

        public async Task<OrderDto?> GetOrderAsync(string orderNumber)
        {
            var order = await _orderRepository.GetByOrderNumberAsync(orderNumber);
            return order is null ? null : OrderMapper.ToDto(order);
        }
    }
}
