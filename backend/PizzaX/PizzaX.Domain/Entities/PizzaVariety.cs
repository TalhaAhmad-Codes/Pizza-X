using PizzaX.Domain.Common;

namespace PizzaX.Domain.Entities
{
    public sealed class PizzaVariety : BaseCategory<Pizza>
    {
        // Constructors
        private PizzaVariety() : base() { }

        private PizzaVariety(string variety) : base(variety) { }

        // Method - Create a new object
        public static PizzaVariety Create(string name)
        {
            Guard.AgainstNotContainPart(name, "pizza", "Pizza variety");

            return new(name);
        }
    }
}
