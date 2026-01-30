using PizzaX.Domain.Common;
using PizzaX.Domain.Common.Entities;
using PizzaX.Domain.ValueObjects.BaseProduct;
using PizzaX.Domain.ValueObjects.Deal;

namespace PizzaX.Domain.Entities
{
    public sealed class Deal : AuditableEntity
    {
        // Attributes
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public ICollection<DealItem> Items { get; private set; }
        public Price Price { get; private set; }

        // Constructors
        private Deal() { }

        private Deal(string name, string? description, ICollection<DealItem> items, decimal price)
        {
            name = Function.Simplify(name, true)!;
            Guard.AgainstInvalidRegexPattern(RegexPattern.DealName, name, nameof(Deal));
            Guard.AgainstWhitespace(description, nameof(Description));

            Name = name;
            Description = Function.Simplify(description);
            Items = items;
            Price = Price.Create(price);
        }

        // Method - Create a new object
        public static Deal Create(string name, string? description, ICollection<DealItem> items, decimal price)
            => new(name, description, items, price);

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

        public void AddDealItem(DealItem item)
        {
            Items.Add(item);
            MarkUpdated();
        }

        public void RemoveDealItem(DealItem item)
        {
            Items.Remove(item);
            MarkUpdated();
        }
    }
}
