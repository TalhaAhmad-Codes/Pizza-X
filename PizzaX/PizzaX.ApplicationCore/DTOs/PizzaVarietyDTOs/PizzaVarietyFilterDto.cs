using PizzaX.ApplicationCore.DTOs.Common;

namespace PizzaX.ApplicationCore.DTOs.PizzaVarietyDTOs
{
    public sealed class PizzaVarietyFilterDto : BaseFilterDto
    {
        public string? Name { get; init; }
    }
}
