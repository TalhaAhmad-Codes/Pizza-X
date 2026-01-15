using PizzaX.Application.DTOs.Common;

namespace PizzaX.Application.DTOs.ProductDTOs.BaseProductUpdateDtos
{
    // Update image
    public class ProductUpdateImageDto : BaseDto
    {
        // Data field
        public byte[]? Image { get; init; }
    }

    // Update price
    public class ProductUpdatePriceDto : BaseDto
    {
        // Data field
        public decimal Price { get; init; }
    }

    // Update quantity
    public class ProductUpdateQuantityDto : BaseDto
    {
        // Data field
        public int Quantity { get; init; }
    }

    // Update description
    public class ProductUpdateDescriptionDto : BaseDto
    {
        // Data field
        public string? Description { get; init; }
    }
}
