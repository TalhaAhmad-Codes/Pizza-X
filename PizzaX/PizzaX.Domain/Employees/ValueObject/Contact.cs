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

            if (number.Length != 11)
                throw new DomainException("The number must be exactly 11 digits long.");

            if (!number.All(char.IsDigit))
                throw new DomainException("Contact number must contain digits only.");

            return new Contact(number);
        }

        // Method - To string convertor
        public override string ToString() => Number;
    }
}
