using PizzaX.Domain.Common;

namespace PizzaX.Domain.Pizzas.Entities
{
    public sealed class PizzaVariety : BaseEntity
    {
        // Attributes
        public string Name { get; private set; }

        // Constructors
        private PizzaVariety() { }

        private PizzaVariety(string name)
        {
            Guard.AgainstNull(name, nameof(Name));
            Name = name;
        }

        public static PizzaVariety Create(string name)
            => new(name);

        // Method - Update name of the pizza variety
        public void Rename(string newName)
        {
            Guard.AgainstNull(newName, nameof(Name));
            Name = newName;
            MarkUpdated();
        }
    }
}
