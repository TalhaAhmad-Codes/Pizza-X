using PizzaX.Application.DTOs.Common;

namespace PizzaX.Application.DTOs.DealItemDTOs
{
    public sealed class DealItemFilterDto : BaseFilterDto
    {
        public Guid? ProductId { get; init; }
        public Guid? DealId { get; init; }
        public int? MinQuantity { get; init; }
        public int? MaxQuantity { get; init; }
    }
}
