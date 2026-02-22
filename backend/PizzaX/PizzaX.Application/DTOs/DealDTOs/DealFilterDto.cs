using PizzaX.Application.DTOs.Common;

namespace PizzaX.Application.DTOs.DealDTOs
{
    public sealed class DealFilterDto : BaseFilterDto
    {
        public Guid? DealItemId { get; init; }
        public string? Name { get; init; }
        public decimal? MinPrice { get; init; }
        public decimal? MaxPrice { get; init; }
    }
}
