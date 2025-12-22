using PizzaX.ApplicationCore.DTOs.Common;
using PizzaX.Domain.Pizzas.Enums;

namespace PizzaX.ApplicationCore.DTOs.PizzaDTOs
{
    public sealed class PizzaFilterDto : BaseFilterDto
    {
        public PizzaSize? Size { get; init; }
        public int? PizzaVarietyId { get; init; }
        public bool? IsAvailable { get; init; }
        public decimal? MinPrice { get; init; }
        public decimal? MaxPrice { get; init; }
    }
}
