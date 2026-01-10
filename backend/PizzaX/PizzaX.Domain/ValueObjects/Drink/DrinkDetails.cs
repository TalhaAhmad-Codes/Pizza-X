using PizzaX.Domain.Common;

namespace PizzaX.Domain.ValueObjects.Drink
{
    public sealed class DrinkDetails
    {
        // Attributes
        public string Company { get; }
        public string? RetailerContactNumber { get; }

        // Constructor
        private DrinkDetails(string company, string? reatilerContactNumber)
        {
            Guard.AgainstNullOrWhitespace(company, nameof(Company));
            Guard.AgainstWhitespace(reatilerContactNumber, nameof(RetailerContactNumber));

            Company = company;
            RetailerContactNumber = reatilerContactNumber;
        }

        // Method - Create a new object
        public static DrinkDetails Create(string company, string? reatilerContactNumber)
            => new(company, reatilerContactNumber);

        // Method - Convert to string
        public override string ToString()
            => $"{Company} | {RetailerContactNumber}";
    }
}
