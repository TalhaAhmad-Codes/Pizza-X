using PizzaX.ApplicationCore.DTOs.Common;
using PizzaX.ApplicationCore.DTOs.PizzaDTOs;

namespace PizzaX.ApplicationCore.DTOs.OrderDTOs
{
    public sealed class CreateOrderItemDto : BaseDto
    {
        public int PizzaId { get; init; }
        public int Quantity { get; init; }
        public PizzaCustomizationDto Customization { get; init; } = default!;
    }
}
