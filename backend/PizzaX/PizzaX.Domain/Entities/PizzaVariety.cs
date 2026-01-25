using PizzaX.Domain.Common;
using PizzaX.Domain.Common.Entities;

namespace PizzaX.Domain.Entities
{
    public sealed class PizzaVariety : AuditableEntity
    {
        // Attribute
        public string Name { get; private set; }
        public readonly List<Pizza> _pizzas = new();

        // Navigation Property
        public IReadOnlyCollection<Pizza> Pizzas => _pizzas;

        // Constructor
        private PizzaVariety() { }

        private PizzaVariety(string name)
        {
            Guard.AgainstNullOrWhitespace(name, nameof(PizzaVariety));

            Name = name.Trim().ToLower();
        }

        // Method - Create a new object
        public static PizzaVariety Create(string name)
            => new(name);

        /*****************************************************/
        /* Methods to change properties of the pizza variety */
        /*****************************************************/

        // Update variety name
        public void UpdateName(string name)
        {
            Guard.AgainstNullOrWhitespace(name, nameof(PizzaVariety));

            Name = name.Trim().ToLower();
        }

        // Add pizza
        public void AddPizza(Pizza pizza)
        {
            // If the pizza already exists
            if (_pizzas.Any(p => p.Id == pizza.Id))
                throw new DomainException($"The given pizza of id({pizza.Id}) not found in the list.");

            _pizzas.Add(pizza);
            MarkUpdated();
        }

        // Remove pizza
        public void RemovePizza(Pizza pizza)
        {
            // If the pizza doesn't exist
            if (!_pizzas.Remove(pizza))
                throw new DomainException("The given pizza not found.");
            
            MarkUpdated();
        }
    }
}
