using PizzaX.ApplicationCore.DTOs.OrderDTOs;
using PizzaX.Domain.Orders.Entities;
using PizzaX.Domain.Orders.ValueObjects;
using PizzaX.Domain.Pizzas.Entities;
using PizzaX.Domain.Pizzas.ValueObjects;

namespace PizzaX.ApplicationCore.Factories
{
    internal static class OrderFactory
    {
        public static Order Create(
            CreateOrderDto dto,
            IReadOnlyDictionary<int, Pizza> pizzasById)
        {
            var order = Order.Create(
                userId: dto.UserId, 
                deliveryInfo: DeliveryInfo.Create(
                    customerName: dto.CustomerName,
                    address: dto.Address,
                    city: dto.City,
                    phone: dto.Phone
                ),
                paymentMethod: dto.PaymentMethod);

            foreach (var item in dto.itemDtos)
            {
                var pizza = pizzasById[item.PizzaId];

                var customization = PizzaCustomization.Create(
                    item.Customization.ExtraCheese,
                    item.Customization.ExtraSauce,
                    item.Customization.ExtraToppings);

                order.AddItem(
                    pizza.Id,
                    item.Quantity,
                    pizza.Price);
                    //customization);
            }

            return order;
        }
    }
}
