using PizzaX.Domain.Enums.Drink;
using PizzaX.Domain.ValueObjects.Drink;

namespace PizzaX.Domain.Entities
{
    public sealed class Drink : Product
    {
        // Attributes
        public DrinkType DrinkType { get; private set; }
        public DrinkDetails DrinkDetails { get; private set; }

        // Constructors
        private Drink() : base() { }

        private Drink(byte[]? image, decimal unitPrice, int quantity, string? description, DrinkType drinkType, DrinkDetails drinkDetails)
            : base(image, unitPrice, quantity, description)
        {
            DrinkType = drinkType;
            DrinkDetails = drinkDetails;
        }

        // Method - Create new object
        public static Drink Create(byte[]? image, decimal unitPrice, int quantity, string? description, DrinkType drinkType, DrinkDetails drinkDetails)
            => new(image, unitPrice, quantity, description, drinkType, drinkDetails);
    }
}
