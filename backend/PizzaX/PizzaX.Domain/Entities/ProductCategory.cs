using PizzaX.Domain.Common;

namespace PizzaX.Domain.Entities
{
    public sealed class ProductCategory : BaseCategory<Product>
    {
        // Constructors
        private ProductCategory() : base() { }
        
        private ProductCategory(string category) : base(category) { }

        // Method - Create a new object
        public static ProductCategory Create(string category)
        {
            Guard.AgainstIllegalStringPart(category, "pizza", nameof(category));

            return new(category);
        }
    }
}
