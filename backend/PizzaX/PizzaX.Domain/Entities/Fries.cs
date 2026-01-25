using PizzaX.Domain.Common;

namespace PizzaX.Domain.Entities
{
    public sealed class Fries : Product
    {
        // Attributes
        public string Category { get; private set; }

        // Constructors
        private Fries() : base() { }

        private Fries(byte[]? image, decimal unitPrice, int quantity, string? description, string category)
            : base(image, unitPrice, quantity, description)
        {
            Guard.AgainstNullOrWhitespace(category, nameof(Category));

            Category = category.Trim().ToLower();
        }

        // Method - Create new object
        public static Fries Create(byte[]? image, decimal unitPrice, int quantity, string? description, string category)
            => new(image, unitPrice, quantity, description, category);

        // Method - Update Category
        public void UpdateCategory(string category)
        {
            Guard.AgainstNullOrWhitespace(category, nameof(Category));

            Category = category.Trim().ToLower();
        }
    }
}
