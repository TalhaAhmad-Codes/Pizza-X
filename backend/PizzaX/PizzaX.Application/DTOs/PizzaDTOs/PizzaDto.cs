using PizzaX.Application.DTOs.ProductDTOs.Common;
using PizzaX.Domain.Enums.Pizza;

namespace PizzaX.Application.DTOs.PizzaDTOs
{
    public sealed class PizzaDto : BaseProductDto
    {
        public Guid VarietyId { get; init; }
        public PizzaSize Size { get; init; }
    }
}
