using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.DealItemDTOs;

namespace PizzaX.Application.DTOs.DealDTOs
{
    public sealed class DealDto : BaseAuditableDto
    {
        public string Name { get; init; }
        public string? Description { get; init; }
        public List<DealItemDto> DealItems { get; init; }
        public decimal Price { get; init; }
    }
}
