using PizzaX.Domain.Common;
using PizzaX.Domain.Common.Entities;
using PizzaX.Domain.ValueObjects.BaseProduct;

namespace PizzaX.Domain.Entities
{
    public sealed class Deal : AuditableEntity
    {
        // Attributes
        public string Name { get; private set; }
        public string? Description { get; private set; }
        //private List<DealItem> dealItems = new();
        public ICollection<DealItem> DealItems;
        public Price Price { get; private set; }

        // Constructors
        private Deal() { }

        private Deal(string name, string? description, decimal price)
        {
            name = Function.Simplify(name, true)!;
            Guard.AgainstInvalidRegexPattern(RegexPattern.DealName, name, nameof(Deal));
            Guard.AgainstWhitespace(description, nameof(Description));

            Name = name;
            Description = Function.Simplify(description);
            Price = Price.Create(price);
        }

        // Method - Create a new object
        public static Deal Create(string name, string? description, decimal price)
            => new(name, description, price);

        /*******************************/
        /* Methods - Update Properties */
        /*******************************/

        public void UpdateName(string name)
        {
            name = Function.Simplify(name, true)!;
            Guard.AgainstInvalidRegexPattern(RegexPattern.DealName, name, nameof(Deal));

            Name = name;
            MarkUpdated();
        }

        public void UpdateDescription(string? description)
        {
            Guard.AgainstWhitespace(description, nameof(Description));

            Description = description;
            MarkUpdated();
        }

        public void UpdatePrice(decimal price)
        {
            Price = Price.Create(price);
            MarkUpdated();
        }
    }
}
