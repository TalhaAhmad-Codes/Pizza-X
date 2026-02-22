using PizzaX.Application.DTOs.Common;

namespace PizzaX.Application.DTOs.DealItemDTOs.DealItemUpdateDtos
{
    public sealed class DealItemUpdateQuantityDto : BaseDto
    {
        public int Quantity { get; init; }
    }

    public sealed class DealItemChangeProductDto : BaseDto
    {
        public Guid ProductId { get; init; }
    }
}
