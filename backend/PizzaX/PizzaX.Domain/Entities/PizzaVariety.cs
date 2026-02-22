using PizzaX.Domain.Common;

namespace PizzaX.Domain.Entities
{
    public sealed class PizzaVariety
    {
        // Constructors
        private PizzaVariety() { }

        private PizzaVariety(string variety) { }

        // Method - Create a new object
        public static PizzaVariety Create(string name)
        {
            Guard.AgainstNotContainPart(name, "pizza", "Pizza variety");

            return new(name);
        }
    }
}
