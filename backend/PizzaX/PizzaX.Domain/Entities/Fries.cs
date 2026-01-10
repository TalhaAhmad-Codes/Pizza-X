namespace PizzaX.Domain.Entities
{
    public sealed class Fries : Product
    {
        // Attributes
        public Guid FriesCategoryId { get; private set; }

        // Navigation properties
        public FriesCategory FriesCategory { get; private set; }

        // Constructors
        private Fries() : base() { }

        private Fries(byte[]? image, decimal unitPrice, int quantity, string? description, Guid friesCategoryId)
            : base(image, unitPrice, quantity, description) => FriesCategoryId = friesCategoryId;

        // Method - Create new object
        public static Fries Create(byte[]? image, decimal unitPrice, int quantity, string? description, Guid friesCategoryId)
            => new(image, unitPrice, quantity, description, friesCategoryId);
    }
}
