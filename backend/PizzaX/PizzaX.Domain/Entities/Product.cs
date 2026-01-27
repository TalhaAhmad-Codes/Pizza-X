using PizzaX.Domain.Common;

namespace PizzaX.Domain.Entities
{
    public sealed class Product : BaseProduct
    {
        // Attributes
        public string Name { get; private set; }
        public Guid CategoryId { get; private set; }

        // Navigation
        public ProductCategory Category { get; private set; }

        // Constructors
        private Product() : base() { }

        private Product(byte[]? image, decimal unitPrice, int quantity, string? description, string name, Guid categoryId) : base(image, unitPrice, quantity, description)
        {
            Guard.AgainstNullOrWhitespace(name, nameof(Name));

            Name = Function.Simplify(name, true)!;
        }

        // Method - Create a new object
        public static Product Create(byte[]? image, decimal unitPrice, int quantity, string? description, string name, Guid categoryId)
            => new(image, unitPrice, quantity, description, name, categoryId);

        /*******************************/
        /* Methods - Update properties */
        /*******************************/

        public void UpdateName(string name)
        {
            Guard.AgainstNullOrWhitespace(name, nameof(Name));

            Name = Function.Simplify(name, true)!;
            MarkUpdated();
        }
    }
}
