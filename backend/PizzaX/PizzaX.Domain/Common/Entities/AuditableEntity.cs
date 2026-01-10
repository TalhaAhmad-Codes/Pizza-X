namespace PizzaX.Domain.Common.Entities
{
    public abstract class AuditableEntity : BaseEntity
    {
        public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; protected set; }

        protected void MarkUpdated()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
