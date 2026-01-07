using PizzaX.Domain.Common;

namespace PizzaX.Domain.ValueObjects.Drink
{
    public sealed class DrinkDetails
    {
        // Attributes
        public string Company { get; }
        public string? RetailerContactNumber { get; }
        public DateTime PurchasedDate { get; }

        // Constructor
        private DrinkDetails(string company, string? reatilerContactNumber, DateTime purchasedDate)
        {
            Guard.AgainstNullOrWhitespace(company, nameof(Company));
            Guard.AgainstWhitespace(reatilerContactNumber, nameof(RetailerContactNumber));

            Company = company;
            RetailerContactNumber = reatilerContactNumber;
            PurchasedDate = purchasedDate;
        }

        // Method - Create a new object
        public static DrinkDetails Create(string company, string? reatilerContactNumber, DateTime purchasedDate)
            => new(company, reatilerContactNumber, purchasedDate);

        // Method - Convert to string
        public override string ToString()
            => $"{Company} | {RetailerContactNumber} | {PurchasedDate}";
    }
}
