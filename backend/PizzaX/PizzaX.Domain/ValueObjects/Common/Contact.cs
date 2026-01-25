using PizzaX.Domain.Common;
using System.Text.RegularExpressions;

namespace PizzaX.Domain.ValueObjects.Common
{
    public sealed class Contact
    {
        // Attribute
        public string Value { get; }

        // Constructors
        private Contact() { }
        private Contact(string value)
        {
            AgainstInvalidContactNumber(value);
            value = value.Trim();

            Value = value;
        }

        // Method - Create new object
        public static Contact Create(string number)
            => new(number);

        // Method - Check if phone number is valid or not
        private static void AgainstInvalidContactNumber(string number)
        {
            Regex PhoneRegex = new(
                @"^\+?[1-9]\d{0,2}[\s\-\.]?\(?\d{1,4}\)?([\s\-\.]?\d){6,10}$",
                RegexOptions.Compiled
            );

            Guard.AgainstNullOrWhitespace(number, nameof(Contact));

            if (!PhoneRegex.IsMatch(number))
                throw new DomainException("The given contact number is not valid.");
        }

        // Methods - Comparision
        public static bool operator ==(Contact contact, string other)
            => contact.Value == other;

        public static bool operator !=(Contact contact, string other)
            => contact.Value != other;

        // Method - To string
        public override string ToString()
            => Value;
    }
}
