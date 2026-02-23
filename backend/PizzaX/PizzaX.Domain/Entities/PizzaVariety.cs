using PizzaX.Domain.Common;
using PizzaX.Domain.Common.Entities;

namespace PizzaX.Domain.Entities
{
    public sealed class PizzaVariety : AuditableEntity
    {
        // Attributes
        public string Name { get; private set; }

        // Navigation
        public ICollection<Pizza> Pizzas { get; private set; }

        // Constructors
        private PizzaVariety() { }

        private PizzaVariety(string variety)
        {
            Guard.AgainstInvalidRegexPattern(RegexPattern.ProductName, variety, nameof(PizzaVariety));
            Guard.AgainstNotContainPart(variety, "pizza", nameof(PizzaVariety));

            Name = Function.Simplify(variety, true)!;
        }

        // Method - Create a new object
        public static PizzaVariety Create(string name)
            => new(name);

        // Method - Update name of the pizza variety
        public void UpdateName(string variety)
        {
            Guard.AgainstInvalidRegexPattern(RegexPattern.ProductName, variety, nameof(PizzaVariety));
            Guard.AgainstNotContainPart(variety, "pizza", nameof(PizzaVariety));

            Name = Function.Simplify(variety, true)!;
            MarkUpdated();
        }

        // Methods - Comparision
        public static bool operator==(PizzaVariety variety, string name)
            => variety.Name == name.ToLower();
        public static bool operator !=(PizzaVariety variety, string name)
            => variety.Name != name.ToLower();
    }
}
