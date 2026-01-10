namespace PizzaX.Application.DTOs.Common
{
    public abstract class BaseAuditableDto : BaseDto
    {
        // Data fields
        public DateTime CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
    }
}
