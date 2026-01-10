using PizzaX.Application.DTOs.Common;

namespace PizzaX.Application.DTOs.PizzaVarietyDTOs
{
    public sealed class PizzaVarietyDto : BaseAuditableDto
    {
        public string Name { get; init; }
    }
}
