using PizzaX.Domain.Common;
using PizzaX.Domain.Pizzas.Enums;

namespace PizzaX.Domain.Pizzas.Entities
{
    public sealed class Pizza : BaseEntity
    {
        // Attributes
        public byte[]? Image { get; private set; }
        public decimal Price { get; private set; }
        public PizzaSize Size { get; private set; }
        public int NoOfPizzas { get; private set; }
        public string? Description { get; private set; }
        public int PizzaVarietyId { get; private set; }
        public PizzaVariety Variety { get; private set; }

        public bool IsAvailable => NoOfPizzas > 0;

        // Constructors
        private Pizza() { }

        private Pizza(decimal price, PizzaSize size, int noOfPizzas, int varietyId, string? description, byte[]? image)
        {
            // Validation Check
            Guard.AgainstNegative(price, nameof(Price));
            Guard.AgainstZeroOrLess(noOfPizzas, nameof(NoOfPizzas));

            // Assigning values
            Price = price;
            Size = size;
            NoOfPizzas = noOfPizzas;
            PizzaVarietyId = varietyId;
            Description = description;
            Image = image;
        }

        // Method - Create a new pizza
        public static Pizza Create(decimal price, PizzaSize size, int noOfPizzas, int varietyId, string? description = null, byte[]? image = null) 
            => new(price, size, noOfPizzas, varietyId, description, image);

        // Method - Update Price
        public void UpdatePrice(decimal newPrice)
        {
            Guard.AgainstNegative(newPrice, nameof(Price));
            Price = newPrice;
            MarkUpdated();
        }

        // Method - Update the number of pizzas in stock
        public void UpdateNoOfPizzas(int noOfPizzas)
        {
            Guard.AgainstZeroOrLess(noOfPizzas, nameof(NoOfPizzas));
            NoOfPizzas = noOfPizzas;
            MarkUpdated();
        }

        // Method - Update Description
        public void UpdateDescription(string? desc)
        {
            Description = desc;
            MarkUpdated();
        }

        // Method - Update Image
        public void UpdateImage(byte[]? img)
        {
            Image = img;
            MarkUpdated();
        }
    }
}
