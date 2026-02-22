using PizzaX.Application.DTOs.ProductDTOs.Common;
using PizzaX.Domain.Enums.Product;

namespace PizzaX.Application.DTOs.ProductDTOs
{
    public sealed class ProductFilterDto : BaseProductFilterDto
    {
        public ProductType? ProductType { get; init; }
    }
}
