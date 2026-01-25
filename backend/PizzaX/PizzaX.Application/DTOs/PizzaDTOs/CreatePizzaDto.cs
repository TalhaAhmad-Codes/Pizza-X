using PizzaX.Application.DTOs.ProductDTOs;
using PizzaX.Domain.Enums.Pizza;

namespace PizzaX.Application.DTOs.PizzaDTOs
{
    public sealed class CreatePizzaDto : BaseCreateProductDto
    {
        public PizzaSize Size { get; init; }
        public Guid VarietyId { get; init; }
    }
}
