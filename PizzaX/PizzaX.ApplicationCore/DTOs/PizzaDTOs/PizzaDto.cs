using PizzaX.ApplicationCore.DTOs.Common;
using PizzaX.Domain.Pizzas.Enums;

namespace PizzaX.ApplicationCore.DTOs.PizzaDTOs
{
    public sealed class PizzaDto : BaseDto
    {
        public byte[]? Image { get; init; } = null;
        public PizzaSize Size { get; init; }
        public decimal Price { get; init; } = 0;
        public int NoOfPizzas { get; init; } = 0;
        public string? Description { get; init; } = null;
        public int PizzaVarietyId { get; init; }
    }
}
