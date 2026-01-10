using PizzaX.Application.DTOs.Common;

namespace PizzaX.Application.DTOs.ProductDTOs
{
    public abstract class BaseProductDto : BaseAuditableDto
    {
        // Data fields
        public byte[]? Image { get; init; }
        public decimal Price { get; init; }
        public int Quantity { get; init; }
        public string? Description { get; init; }
    }
}
