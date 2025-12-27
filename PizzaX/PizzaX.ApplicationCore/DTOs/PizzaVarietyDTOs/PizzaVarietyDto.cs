using PizzaX.ApplicationCore.DTOs.Common;

namespace PizzaX.ApplicationCore.DTOs.PizzaVarietyDTOs
{
    public sealed class PizzaVarietyDto : AuditableDto
    {
        public string Name { get; init; }
    }
}
