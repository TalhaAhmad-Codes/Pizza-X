using PizzaX.Domain.Common;
using PizzaX.Domain.Common.Entities;
using PizzaX.Domain.Common.Exceptions;

namespace PizzaX.Domain.Entities
{
    public sealed class Variety : AuditableEntity
    {
        // Attribute
        public string Name { get; private set; }
        public readonly List<Pizza> _pizzas = new();

        // Navigation Property
        public IReadOnlyCollection<Pizza> Pizzas => _pizzas;

        // Constructor
        private Variety(string name)
        {
            Guard.AgainstNullOrWhitespace(name, nameof(Variety));

            Name = name;
        }

        // Method - Create a new object
        public static Variety Create(string name)
            => new(name);

        // Method - Add pizza
        public void AddPizza(Pizza pizza)
        {
            // If the pizza already exists
            if (_pizzas.Any(p => p.Id == pizza.Id))
                throw new DuplicateEntityException("The given pizza not found in the list.");

            _pizzas.Add(pizza);
            MarkUpdated();
        }

        // Method - Remove pizza
        public void RemovePizza(Pizza pizza)
        {
            // If the pizza doesn't exist
            if (!_pizzas.Remove(pizza))
                throw new EntityNotFoundException("The given pizza not found.");
            
            MarkUpdated();
        }
    }
}
