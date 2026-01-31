using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.DealItemDTOs;

namespace PizzaX.Application.DTOs.DealDTOs.DealUpdateDtos
{
    public sealed class DealUpdateNameDto : BaseDto
    {
        public string Name { get; init; }
    }

    public sealed class DealUpdateDescriptionDto : BaseDto
    {
        public string? Description { get; init; }
    }

    public sealed class DealUpdatePriceDto : BaseDto
    {
        public decimal Price { get; init; }
    }

    public sealed class DealAddDealItemsDto : BaseDto
    {
        public List<DealItemDto> Items { get; init; }
    }

    public sealed class DealRemoveDealItemDto : BaseDto
    {
        public DealItemDto Item { get; init; }
    }
}
