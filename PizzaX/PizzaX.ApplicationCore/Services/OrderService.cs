using PizzaX.ApplicationCore.DTOs.Common;
using PizzaX.ApplicationCore.DTOs.OrderDTOs;
using PizzaX.ApplicationCore.Factories;
using PizzaX.ApplicationCore.Interfaces.Repositories;
using PizzaX.ApplicationCore.Interfaces.Services;
using PizzaX.ApplicationCore.Mappers;
using PizzaX.Domain.Common;
using PizzaX.Domain.Pizzas.Entities;

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
            // Basic application-level validation
            if (dto.itemDtos.Count == 0)
                throw new DomainException("Order must contain at least one item.");

            // Load all pizzas involved in the order
            var pizzasById = new Dictionary<int, Pizza>();

            foreach (var item in dto.itemDtos)
            {
                Guard.AgainstZeroOrLess(item.Quantity, nameof(item.Quantity));

                if (!pizzasById.ContainsKey(item.PizzaId))
                {
                    var pizza = await _pizzaRepository.GetByIdAsync(item.PizzaId)
                        ?? throw new DomainException($"Pizza with Id {item.PizzaId} not found.");

                    if (!pizza.IsAvailable)
                        throw new DomainException($"Pizza '{pizza.Variety.Name}' is not available.");

                    pizzasById.Add(item.PizzaId, pizza);
                }
            }

            // Create Order aggregate using factory (DTO → Entity)
            var order = OrderFactory.Create(dto, pizzasById);

            // Persist aggregate root
            await _orderRepository.AddAsync(order);

            // Return read model (Entity → DTO)
            return OrderMapper.ToDto(order);

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
            return OrderMapper.ToDto(order!);
        }
    }
}
