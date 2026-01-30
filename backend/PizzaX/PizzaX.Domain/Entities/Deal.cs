using PizzaX.Domain.Common;
using PizzaX.Domain.Common.Entities;
using PizzaX.Domain.ValueObjects.Deal;

namespace PizzaX.Domain.Entities
{
    public sealed class Deal : AuditableEntity
    {
        // Attributes
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public ICollection<DealItem> Items { get; private set; }

        // Constructors
        private Deal() { }

        private Deal(string name, string? description, ICollection<DealItem> items)
        {
            name = Function.Simplify(name, true)!;
            Guard.AgainstInvalidRegexPattern(RegexPattern.DealName, name, nameof(Deal));
            Guard.AgainstWhitespace(description, nameof(Description));

            Name = name;
            Description = Function.Simplify(description);
            Items = items;
        }

        // Method - Create a new object
        public static Deal Create(string name, string? description, ICollection<DealItem> items)
            => new(name, description, items);

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

        public void AddProduct(DealItem item)
        {
            Items.Add(item);
            MarkUpdated();
        }

        public void RemoveProduct(DealItem item)
        {
            Items.Remove(item);
            MarkUpdated();
        }
    }
}
