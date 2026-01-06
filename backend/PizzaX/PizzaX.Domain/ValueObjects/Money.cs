using PizzaX.Domain.Common;

namespace PizzaX.Domain.ValueObjects
{
    public sealed class Money
    {
        // Attributes
        public decimal Amount { get; }

        // Constructor
        public Money(decimal amount)
        {
            // Guard invalid data
            Guard.AgainstNegativeValue(amount, nameof(Amount));

            // Assigning value
            Amount = amount;
        }

        // Method - Create a new object
        public static Money Create(decimal amount)
            => new(amount);

        // Methods - Comparision operators
        public static bool operator ==(Money left, Money right)
            => left.Amount == right.Amount;

        public static bool operator !=(Money left, Money right)
            => left.Amount != right.Amount;

        // Method - Override string
        public override string ToString()
            => $"{Amount}";
    }
}
