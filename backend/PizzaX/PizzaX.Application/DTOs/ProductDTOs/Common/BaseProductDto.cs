using PizzaX.Application.DTOs.Common;
using PizzaX.Domain.Enums.Product;

namespace PizzaX.Application.DTOs.ProductDTOs.Common
{
    public class BaseProductDto : BaseAuditableDto
    {
        public Guid ProductId { get; init; }
        public byte[]? Image { get; init; }
        public decimal Price { get; init; }
        public string? Description { get; init; }
        public StockStatus StockStatus { get; init; }
    }
}
