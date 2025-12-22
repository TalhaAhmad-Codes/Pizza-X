using PizzaX.Domain.Common;

namespace PizzaX.Domain.Employees.ValueObject
{
    public sealed class Contact
    {
        // Attributes
        public string Number { get; }

        // Constructor
        private Contact(string number) => Number = number;

        // Method - Create a contact object
        public static Contact Create(string number)
        {
            Guard.AgainstNull(number, nameof(number));

            foreach (var digit in number)
            {
                if (!char.IsAsciiDigit(digit))
                    throw new DomainException("The number is invalid. It must contain only digits.");
            }

            return new Contact(number);
        }

        // Method - To string convertor
        public override string ToString()
        {
            return Number;
        }
    }
}
