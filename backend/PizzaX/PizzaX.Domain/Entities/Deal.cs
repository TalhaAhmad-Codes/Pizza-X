using PizzaX.Domain.Common;
using PizzaX.Domain.Common.Entities;

namespace PizzaX.Domain.Entities
{
    public sealed class Deal : AuditableEntity
    {
        // Attributes
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public ICollection<Guid> Products { get; private set; }

        // Constructors
        private Deal() { }

        private Deal(string name, string? description, ICollection<Guid> products)
        {
            Guard.AgainstNullOrWhitespace(name, nameof(Deal));
            Guard.AgainstWhitespace(description, nameof(Description));

            Name = name;
            Description = description;
            Products = products;
        }

        // Method - Create a new object
        public static Deal Create(string name, string? description, ICollection<Guid> products)
            => new(name, description, products);

        /*******************************/
        /* Methods - Update Properties */
        /*******************************/

        public void UpdateName(string name)
        {
            Guard.AgainstNullOrWhitespace(name, nameof(Deal));

            Name = name;
            MarkUpdated();
        }

        public void UpdateDescription(string? description)
        {
            Guard.AgainstWhitespace(description, nameof(Description));

            Description = description;
            MarkUpdated();
        }

        public void AddProduct(Guid productId)
        {
            Products.Add(productId);
            MarkUpdated();
        }

        public void RemoveProduct(Guid productId)
        {
            Products.Remove(productId);
            MarkUpdated();
        }
    }
}
