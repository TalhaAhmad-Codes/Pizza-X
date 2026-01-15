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

        private Drink(byte[]? image, decimal unitPrice, int quantity, string? description, DrinkType drinkType, string companyName, string? retailerContactNumber)
            : base(image, unitPrice, quantity, description)
        {
            DrinkType = drinkType;
            DrinkDetails = DrinkDetails.Create(companyName, retailerContactNumber);
        }

        // Method - Create new object
        public static Drink Create(byte[]? image, decimal unitPrice, int quantity, string? description, DrinkType drinkType, string companyName, string? retailerContactNumber)
            => new(image, unitPrice, quantity, description, drinkType, companyName, retailerContactNumber);

        // Methods - Update drink details
        public void UpdateDrinkDetailsCompanyName(string companyName)
        {
            DrinkDetails = DrinkDetails.Create(companyName, DrinkDetails.RetailerContactNumber);

            MarkUpdated();
        }

        public void UpdateDrinkDetailsRetailerContactNumber(string? retailerContactNumber)
        {
            DrinkDetails = DrinkDetails.Create(DrinkDetails.Company, retailerContactNumber);

            MarkUpdated();
        }
    }
}
