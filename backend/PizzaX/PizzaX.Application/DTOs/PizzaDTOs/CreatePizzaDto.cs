using PizzaX.Application.DTOs.ProductDTOs.Common;
using PizzaX.Domain.Enums.Pizza;

namespace PizzaX.Application.DTOs.PizzaDTOs
{
    public sealed class CreatePizzaDto
    {
        public Guid ProductId { get; init; }
        public Guid VarietyId { get; init; }
        public PizzaSize Size { get; init; }

        public BaseCreateProductDto? ProductDto { get; init; } = null;
    }
}
