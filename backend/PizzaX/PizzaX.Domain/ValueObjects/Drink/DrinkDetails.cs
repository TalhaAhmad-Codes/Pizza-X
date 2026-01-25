using PizzaX.Domain.Common;
using PizzaX.Domain.ValueObjects.Common;

namespace PizzaX.Domain.ValueObjects.Drink
{
    public sealed class DrinkDetails
    {
        // Attributes
        public string Company { get; }
        public Contact? RetailerContactNumber { get; }

        // Constructors
        private DrinkDetails() { }
        private DrinkDetails(string company, string? reatilerContactNumber)
        {
            Guard.AgainstNullOrWhitespace(company, nameof(Company));

            Company = company.Trim().ToLower();
            RetailerContactNumber = Contact.Create(reatilerContactNumber!);
        }

        // Method - Create a new object
        public static DrinkDetails Create(string company, string? reatilerContactNumber)
            => new(company, reatilerContactNumber);

        // Method - Convert to string
        public override string ToString()
            => $"{Company} | {RetailerContactNumber}";
    }
}
