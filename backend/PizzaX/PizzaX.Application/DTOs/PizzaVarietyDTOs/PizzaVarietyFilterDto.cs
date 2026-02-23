using PizzaX.Application.DTOs.Common;

namespace PizzaX.Application.DTOs.PizzaVarietyDTOs
{
    public sealed class PizzaVarietyFilterDto : BaseFilterDto
    {
        public string? Name { get; init; }
    }
}
