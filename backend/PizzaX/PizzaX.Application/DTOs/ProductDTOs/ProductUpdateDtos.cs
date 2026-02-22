using PizzaX.Application.DTOs.Common;
using PizzaX.Domain.Enums.Product;

namespace PizzaX.Application.DTOs.ProductDTOs.ProductUpdateDtos
{
    public sealed class ProductUpdateStockStatusDto : BaseDto
    {
        public StockStatus StockStatus { get; init; }
    }

    public sealed class ProductUpdateDescriptionDto : BaseDto
    {
        public string? Description { get; init; }
    }

    public sealed class ProductUpdatePriceDto : BaseDto
    {
        public decimal Price { get; init; }
    }

    public sealed class ProductUpdateImageDto : BaseDto
    {
        public byte[]? Image { get; init; }
    }
}
