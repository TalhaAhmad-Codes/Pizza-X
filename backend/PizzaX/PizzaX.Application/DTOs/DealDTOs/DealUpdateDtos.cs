using PizzaX.Application.DTOs.Common;

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
        public List<DealItemForDealDto> DealItemItems { get; init; }
    }

    public sealed class DealRemoveDealItemDto : BaseDto
    {
        public Guid DealItemId { get; init; }
    }
}
