using PizzaX.Domain.Common;
using System.Text.RegularExpressions;

namespace PizzaX.Domain.ValueObjects.User
{
    public sealed class Email
    {
        // Attribute
        public string Value { get; }

        // Constructors
        private Email() { }
        private Email(string email)
        {
            // Guard against invalid value
            Guard.AgainstNullOrWhitespace(email, "Email");
            VerifyFormat(email);

            Value = Function.Simplify(email)!;
        }

        // Method - Create a new object
        public static Email Create(string email)
            => new(email);

        // Method - Check if email format is valid or not
        private static void VerifyFormat(string email)
        {
            var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, pattern))
                throw new DomainException("The given email format is invalid.");
        }

        // Method - Convert to string
        public override string ToString()
            => Value;
    }
}
