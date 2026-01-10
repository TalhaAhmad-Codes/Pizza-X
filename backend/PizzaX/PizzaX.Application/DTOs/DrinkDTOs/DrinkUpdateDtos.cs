using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.ProductDTOs.BaseProductUpdateDtos;

namespace PizzaX.Application.DTOs.DrinkDTOs.DrinkUpdateDtos
{
    // Update image
    public sealed class DrinkUpdateImageDto : BaseProductUpdateImageDto { }

    // Update price
    public sealed class DrinkUpdatePriceDto : BaseProductUpdatePriceDto { }

    // Update quantity
    public sealed class DrinkUpdateQuantityDto : BaseProductUpdateQuantityDto { }

    // Update description
    public sealed class DrinkUpdateDescriptionDto : BaseProductUpdateDescriptionDto { }

    // Update drink details
    public sealed class DrinkUpdateDetailsDto : BaseDto
    {
        public string CompanyName { get; init; }
        public string? RetailerContactNumber { get; init; }
    }
}
