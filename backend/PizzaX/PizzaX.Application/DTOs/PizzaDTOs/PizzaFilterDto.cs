using PizzaX.Application.DTOs.ProductDTOs.Common;
using PizzaX.Domain.Enums.Pizza;

namespace PizzaX.Application.DTOs.PizzaDTOs
{
    public sealed class PizzaFilterDto : BaseProductFilterDto
    {
        public Guid? VarietyId { get; init; }
        public PizzaSize? Size { get; init; }
    }
}
