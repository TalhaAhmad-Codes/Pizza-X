using PizzaX.Domain.Enums.Pizza;

namespace PizzaX.Domain.Entities
{
    public sealed class Pizza : Product
    {
        // Attributes
        public PizzaSize Size { get; private set; }
        public Guid VarietyId { get; private set; }

        // Navigation properties
        public PizzaVariety Variety { get; private set; }

        // Constructors
        private Pizza() : base() { }

        private Pizza(byte[]? image, decimal unitPrice, int quantity, string? description, PizzaSize size, Guid varietyId)
            : base(image, unitPrice, quantity, description)
        {
            Size = size;
            VarietyId = varietyId;
        }

        // Method - Create a new object
        public static Pizza Create(byte[]? image, decimal unitPrice, int quantity, string? description, PizzaSize size, Guid varietyId)
            => new(image, unitPrice, quantity, description, size, varietyId);
    }
}
