using PizzaX.Application.DTOs.Common;

namespace PizzaX.Application.DTOs.ProductDTOs.BaseProductUpdateDtos
{
    // Update image
    public abstract class BaseProductUpdateImageDto : BaseDto
    {
        // Data field
        public byte[]? Image { get; init; }
    }

    // Update price
    public abstract class BaseProductUpdatePriceDto : BaseDto
    {
        // Data field
        public decimal Price { get; init; }
    }

    // Update quantity
    public abstract class BaseProductUpdateQuantityDto : BaseDto
    {
        // Data field
        public int Quantity { get; init; }
    }

    // Update description
    public abstract class BaseProductUpdateDescriptionDto : BaseDto
    {
        // Data field
        public string? Description { get; init; }
    }
}
