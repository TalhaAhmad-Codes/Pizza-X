using PizzaX.Domain.Common;
using System.Text.RegularExpressions;

namespace PizzaX.Domain.Users.ValueObjects
{
    public sealed class Email
    {
        public string Value { get; }

        // Constructor
        private Email(string value) => Value = value;

        // Method - Create an email object
        public static Email Create(string value)
        {
            // Checking if email is null
            Guard.AgainstNull(value, nameof(Email));

            // Matching pattern of the email
            var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(value, pattern))
                throw new DomainException("Invalid email format.");

            return new Email(value);
        }

        // Method - To string convertor
        public override string ToString() => Value;
    }
}
